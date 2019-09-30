using System;
using System.ComponentModel.DataAnnotations;

namespace AdisBlog.Core.Persistence.Requests
{
    public class FollowUser
    {
        [Required]
        public Guid FollowingUserId { get; set; }
    }
}