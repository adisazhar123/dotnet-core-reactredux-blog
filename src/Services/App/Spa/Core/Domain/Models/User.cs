using System.Collections.Generic;

namespace AdisBlog.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        
        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<FavoritePost> FavoritePosts { get; set; }

    }
}