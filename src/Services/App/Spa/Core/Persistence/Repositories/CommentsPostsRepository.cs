using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdisBlog.Data;
using AdisBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace AdisBlog.Core.Persistence.Repositories
{
    public class CommentsPostsRepository
    {
        private readonly BlogsDbContext _context;
        
        public CommentsPostsRepository(BlogsDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> CreateCommentAsync(Guid postId, Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public IEnumerable<Comment> GetComments(Guid postId)
        {
            var comments = _context.Comments.Where(c => c.Post.Id == postId);
            
            return comments;
        }
    }
}