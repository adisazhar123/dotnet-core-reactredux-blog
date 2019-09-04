using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AdisBlog.Core.Persistence.Dtos;
using AdisBlog.Core.Persistence.Repositories;
using AdisBlog.Core.Persistence.Requests;
using AdisBlog.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AdisBlog.Core.Persistence.Services
{
    public class AccountService
    {
        private readonly IConfiguration _configuration;
        private readonly UsersRepository _usersRepository;

        private readonly IEnumerable<User> _users = new List<User>
        {
/*            new User { Id = 1, Username = "fred", Password = "123", Role = "Administrator"},
            new User { Id = 2, Username = "alice", Password = "456", Role = "Accountant"},
            new User { Id = 3, Username = "joe", Password = "789", Role = "Guest"}*/
        };

        public AccountService(IConfiguration configuration, UsersRepository usersRepository)
        {
            _configuration = configuration;
            _usersRepository = usersRepository;
        }

        public IEnumerable<User> Users()
        {
            return _users;
        }

        public UsersLoginDto Login(Login login)
        {
            var user = _usersRepository.FindUserLogin(login.Username);
            if (user == null)
            {
                return new UsersLoginDto()
                {
                    Success = false,
                    Message = "Account not found. Wrong credentials.",
                };
            }
            
            bool validPassword = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
            if (!validPassword)
            {
                return new UsersLoginDto
                {
                    Message = "Account not found. Wrong credentials.",
                    Success = false
                };
            }

            var signingKey = Convert.FromBase64String(_configuration["Jwt:SigningSecret"]);
            var expiryDuration = int.Parse(_configuration["Jwt:ExpiryDuration"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,              // Not required as no third-party is involved
                Audience = null,            // Not required as no third-party is involved
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                Subject = new ClaimsIdentity(new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return new UsersLoginDto
            {
                token = token,
                Message = "Logged in succesfully.",
                UserId = user.Id
            };
        }

        public async Task<RegisterDto> Register(Register register)
        {
            return await _usersRepository.RegisterAsync(register);
        }
    }
}