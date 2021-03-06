using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.ViewModels;
using AdisBlog.Core.Persistence.Requests;
using AdisBlog.Models;

namespace AdisBlog.Core.Domain.Repositories
{
    public interface IPostsRepository
    {
        Task<Post> CreatePostAsync(Post post, List<SelectTag> tags);
        Task<GetAllPostsVm> GetPostsAsync(int page, int size);
        Task<Post> DeletePost(Guid postId);
        Task<Post> GetPostAsync(Guid postId);
        Task<bool> IsPostFavorite(Guid postId, Guid userId);
    }
}