using System.ComponentModel.DataAnnotations;

namespace AdisBlog.Core.Persistence.Requests
{
    public class Register
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}