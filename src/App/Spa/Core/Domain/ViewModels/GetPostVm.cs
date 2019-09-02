using AdisBlog.Models;

namespace AdisBlog.Core.Domain.ViewModels
{
    public class GetPostVm
    {
        public Post Post { get; set; }
        public bool ?IsFavorite { get; set; }
    }
}