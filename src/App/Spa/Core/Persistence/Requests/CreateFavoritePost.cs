using System;
using System.ComponentModel.DataAnnotations;

namespace AdisBlog.Core.Persistence.Requests
{
    public class CreateFavoritePost
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid PostId { get; set; }
    }
}