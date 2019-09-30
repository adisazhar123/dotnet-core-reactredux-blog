using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using AdisBlog.Core.Persistence.Repositories;
using AdisBlog.Core.Persistence.Requests;
using AdisBlog.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdisBlog.Controllers
{
    [Route("api")]
    [Authorize(Roles = "user,admin")]
    public class UsersController : Controller
    {
        private readonly UsersRepository _repository;
        
        public UsersController(UsersRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost(Route.UsersFollow)]
        public async Task<IActionResult> FollowUserAsync([FromBody] FollowUser following)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentUGuid = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _repository.FollowUserAsync(currentUGuid, following.FollowingUserId);

            return Ok();
        }
    }
}