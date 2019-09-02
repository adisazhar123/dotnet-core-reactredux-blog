using System;

namespace AdisBlog.Models
{
    public class Comment : BaseModel
    { 
        public string Body { get; set; }
        public virtual Post Post { get; set; }
        public Guid PostId { get; set; }
    }
}