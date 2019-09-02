using System.Threading.Tasks;
using AdisBlog.Core.Persistence.Repositories;
using AdisBlog.Data;
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
            
            return Json(posts);
        }
    }
}