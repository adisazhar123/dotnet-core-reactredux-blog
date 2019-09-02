using System.Collections.Generic;
using AdisBlog.Models;

namespace AdisBlog.Core.Domain.ViewModels
{
    public class GetUserPostsVm
    {
        public IEnumerable<Post> Posts { get; set; }
        public string Username { get; set; }
    }
}