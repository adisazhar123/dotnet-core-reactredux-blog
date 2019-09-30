using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdisBlog.Models
{
    public class Post : BaseModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public string CoverImagePath { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual IList<PostTag> PostTags { get; set; }
    }
}

