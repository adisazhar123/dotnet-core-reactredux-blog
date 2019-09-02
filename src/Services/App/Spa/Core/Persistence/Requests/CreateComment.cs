using System.ComponentModel.DataAnnotations;

namespace AdisBlog.Core.Persistence.Requests
{
    public class CreateComment
    {
        [Required]
        public string Body { get; set; }
    }
}