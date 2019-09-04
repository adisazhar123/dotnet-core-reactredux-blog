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
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpPost("api/login")]
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
        [HttpGet("api/users")]
        public IActionResult Users()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Json(new {
                Users =_accountService.Users(),
                userId = userId
            });
        }
        
        [HttpPost("api/" + Route.UsersRegister)]
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