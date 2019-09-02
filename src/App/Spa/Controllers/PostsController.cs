using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.Repositories;
using AdisBlog.Core.Domain.ViewModels;
using AdisBlog.Core.Persistence.Repositories;
using AdisBlog.Core.Persistence.Requests;
using AdisBlog.Models;
using AdisBlog.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdisBlog.Controllers
{
    [Route("api")]
    [Authorize(Roles = "user,admin")]
    public class PostsController : Controller
    {
        private readonly IPostsRepository _repo;
        private readonly FavoritePostsRepository _favoritePostsRepository;

        public PostsController(IPostsRepository repo, FavoritePostsRepository favoritePostsRepository)
        {
            _repo = repo;
            _favoritePostsRepository = favoritePostsRepository;
        }
        
        [HttpPost(Route.PostsCreate)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePostAsync(Guid userId, [FromBody] CreatePost post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdPost = await _repo.CreatePostAsync(
                new Post
                {
                    Title = post.Title,
                    Body = post.Body,
                    UserId = userId
                }
            );

            return Created(nameof(Route.PostsCreate), createdPost);
        }

        [AllowAnonymous]
        [HttpGet(Route.PostsGetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPostsAsync(int page = 1, int size = 5)
        {
            var posts = await _repo.GetPostsAsync(page, size);
            return Json(posts);
        }
        
        [HttpDelete(Route.PostsDelete)]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            var post = await _repo.DeletePost(postId);
            return Ok(post);
        }
        
        [AllowAnonymous]
        [HttpGet(Route.PostsGetSingle)]
        public async Task<IActionResult> GetPost(Guid postId)
        {
            var post = await _repo.GetPostAsync(postId);
            bool isFavoritePost = false;
            if (User.Identity.IsAuthenticated)
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                isFavoritePost = await _repo.IsPostFavorite(postId, userId);
            }

            var getPostVm = new GetPostVm
            {
                Post = post,
                IsFavorite = isFavoritePost
            };
            return Json(getPostVm);
        }

        [HttpPost("favorite-posts")]
        public async Task<IActionResult> CreateFavoritePost([FromBody] CreateFavoritePost favoritePost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var favPost = new FavoritePost
            {
                PostId = favoritePost.PostId,
                UserId = favoritePost.UserId
            };

            var createFavoritePostVm = await _favoritePostsRepository.CreateFavoritePost(favPost);
            return Ok(createFavoritePostVm);
        }
    }
}