using System.Security.Claims;
using AdisBlog.Core.Persistence.Requests;
using AdisBlog.Core.Persistence.Services;
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
            if (loginResponse == null)
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
    }
}