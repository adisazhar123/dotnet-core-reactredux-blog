using System.ComponentModel.DataAnnotations;

namespace AdisBlog.Core.Persistence.Requests
{
    public class CreatePost
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }
}