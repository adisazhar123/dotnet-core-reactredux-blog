using System;
using AdisBlog.Models;

namespace AdisBlog.Core.Persistence.Dtos
{
    public class UsersLoginDto
    {
        public Guid UserId;
        public string Message;
        public bool Success = true;
        public string token;
    }
}