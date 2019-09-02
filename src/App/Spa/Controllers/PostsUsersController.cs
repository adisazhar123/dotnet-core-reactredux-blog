using System.Linq;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.ViewModels;
using AdisBlog.Core.Persistence.Repositories;
using AdisBlog.Data;
using AdisBlog.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdisBlog.Controllers
{
    [Route("api")]
    public class PostsUsersController : Controller
    {
        private UsersRepository _repo;
        private readonly IMapper _mapper;
        
        public PostsUsersController(UsersRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        [HttpGet("users/{userName}/posts")]
        public async Task<IActionResult> GetUserPosts(string username)
        {
            var posts = await _repo.GetUserPosts(username);
            
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