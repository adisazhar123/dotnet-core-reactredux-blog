using AdisBlog.Models;

namespace AdisBlog.Core.Persistence.Dtos
{
    public class RegisterDto
    {
        public User User { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}