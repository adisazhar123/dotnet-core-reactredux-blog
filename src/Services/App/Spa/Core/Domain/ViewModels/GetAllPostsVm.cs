using System.Collections.Generic;
using AdisBlog.Models;

namespace AdisBlog.Core.Domain.ViewModels
{
    public class GetAllPostsVm
    {
        public IEnumerable<Post> Posts { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string NextPageUrl { get; set; }
        public string PrevPageUrl { get; set; }
        
    }
}