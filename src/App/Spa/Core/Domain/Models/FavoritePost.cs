using System;

namespace AdisBlog.Models
{
    public class FavoritePost : BaseModel
    {
        public Guid PostId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}