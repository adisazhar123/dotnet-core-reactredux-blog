using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AdisBlog.Core.Persistence.Dtos;
using AdisBlog.Core.Persistence.Requests;
using AdisBlog.Core.Persistence.Services;
using AdisBlog.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdisBlog.Controllers
{
    [Route("api")]
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;
        ILogger log;
        public AccountController(AccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            log = logger;
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
            Console.WriteLine("this is in register");
            log.LogError("Heyo");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var registerResponse = await _accountService.Register(register);
            return Json(registerResponse.Message);
        }
    }
}