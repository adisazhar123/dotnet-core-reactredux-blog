using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.Repositories;
using AdisBlog.Core.Domain.ViewModels;
using AdisBlog.Core.Persistence.Requests;
using AdisBlog.Data;
using AdisBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace AdisBlog.Core.Persistence.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly BlogsDbContext _context;
        
        public PostsRepository(BlogsDbContext context)
        {
            _context = context;
        }
        public async Task<Post> CreatePostAsync(Post post, List<SelectTag> tags)
        {
            await _context.Posts.AddAsync(post);
            post.PostTags = new List<PostTag>();
            
            foreach (var tag in tags)
            {
                post.PostTags.Add(new PostTag
                {
                    PostId = post.Id,
                    TagId = Guid.Parse(tag.Value)
                });
            }
            
            await _context.SaveChangesAsync();
            
            return post;
        }

        public async Task<GetAllPostsVm> GetPostsAsync(int page, int size)
        {
            var posts = await _context.Posts
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            var totalPosts = await _context.Posts.CountAsync();
            var totalPages = (int) Math.Ceiling(totalPosts / (float) size);
            
            var getAllPostsVm = new GetAllPostsVm();
            getAllPostsVm.Posts = posts;
            getAllPostsVm.CurrentPage = page;
            getAllPostsVm.TotalPages = totalPages;
            getAllPostsVm.NextPageUrl = page < totalPages ? "192.168.16.106/api/posts?page=" + (page + 1)
                : "192.168.16.106/api/posts?page=" + page;
            getAllPostsVm.PrevPageUrl = page > 1  ? "192.168.16.106/api/posts?page=" + (page - 1)
                : "192.168.16.106/api/posts?page=" + page;

            return getAllPostsVm;
        }

        public async Task<Post> DeletePost(Guid postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<Post> GetPostAsync(Guid postId)
        {
            return await _context.Posts
                .Include(p => p.User)
                .Include(p => p.PostTags)
                    .ThenInclude(pt => pt.Tag)
                .SingleOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<bool> IsPostFavorite(Guid postId, Guid userId)
        {
            return await _context.FavoritePosts
                .SingleOrDefaultAsync(f => f.PostId == postId && f.UserId == userId) != null;
        }
    }
}