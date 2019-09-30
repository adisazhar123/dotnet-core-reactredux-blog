using System;

namespace AdisBlog.Models
{
    public class Following : BaseModel
    {
        public Guid FollowingUserId { get; set; }
        
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}