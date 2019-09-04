using System.Security.Claims;
using System.Threading.Tasks;
using AdisBlog.Core.Persistence.Dtos;
using AdisBlog.Core.Persistence.Requests;
using AdisBlog.Core.Persistence.Services;
using AdisBlog.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdisBlog.Controllers
{
    [Route("api")]
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpPost(Route.UsersLogin)]
        public IActionResult Login([FromBody] Login login)
        {
            var loginResponse = _accountService.Login(login);
            if (! loginResponse.Success)
            {
                return Unauthorized();
            }

            return Json(loginResponse);
        }
        
        [Authorize(Roles = "user,admin")]
        [HttpGet("users")]
        public IActionResult Users()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Json(new {
                Users =_accountService.Users(), userId
            });
        }
        
        [HttpPost(Route.UsersRegister)]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var registerResponse = await _accountService.Register(register);
            return Json(registerResponse.Message);
        }
    }
}