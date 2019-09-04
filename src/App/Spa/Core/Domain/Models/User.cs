using System.Collections.Generic;

namespace AdisBlog.Models
{
    public class User : BaseModel
    {
        public static string RoleUser => "user";
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        
        public virtual IList<Post> Posts { get; set; }
        public virtual IList<FavoritePost> FavoritePosts { get; set; }

    }
}