using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.ViewModels;
using AdisBlog.Core.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdisBlog.Controllers
{
    [Route("api")]
    public class PostsUsersController : Controller
    {
        private UsersRepository _repo;
        
        public PostsUsersController(UsersRepository repo)
        {
            _repo = repo;
        }
        
        [HttpGet("users/{userName}/posts")]
        public async Task<IActionResult> GetUserPosts(string username)
        {
            var posts = await _repo.GetUserPosts(username);
            var myFollowings = User.Identity.IsAuthenticated ? await _repo.GetMyFollowingsAsync(Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)) : null;
            if (myFollowings != null)
            {
                posts.IsFollowing = myFollowings.Any(f => f.FollowingUserId == posts.UserId);
            }
            
            return Json(posts);
        }
        
        [HttpGet("users/{username}/posts/favorite")]
        public async Task<IActionResult> GetUserFavoritePosts(string username)
        {
            var posts = await _repo.GetUserFavoritePosts(username);
            var vm = new GetUserFavoritePostsVm
            {
                Posts = posts
            };
            return Json(vm);
        }
    }
}