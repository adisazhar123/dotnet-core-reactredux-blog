using System.Collections.Generic;

namespace AdisBlog.Models
{
    public class Tag : BaseModel
    {
        public string Title { get; set; }
        public virtual IList<PostTag> PostTags { get; set; }
    }
}