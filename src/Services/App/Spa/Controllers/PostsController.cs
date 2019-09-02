using System;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.Repositories;
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

        public PostsController(IPostsRepository repo)
        {
            _repo = repo;
        }
        
        [HttpPost(Route.POSTS_CREATE)]
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

            return Created(nameof(Route.POSTS_CREATE), createdPost);
        }

        [AllowAnonymous]
        [HttpGet(Route.POSTS_GET_ALL)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPostsAsync(int page = 1, int size = 5)
        {
            var posts = await _repo.GetPostsAsync(page, size);
            return Json(posts);
        }
        
        [HttpDelete(Route.POSTS_DELETE)]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            var post = await _repo.DeletePost(postId);
            return Ok(post);
        }
        
        [AllowAnonymous]
        [HttpGet(Route.POSTS_GET_SINGLE)]
        public async Task<IActionResult> GetPost(Guid postId)
        {
            return Json( await _repo.GetPostAsync(postId));
        }
    }
}