using System;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.ViewModels;
using AdisBlog.Data;
using AdisBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace AdisBlog.Core.Persistence.Repositories
{
    public class FavoritePostsRepository
    {
        private readonly BlogsDbContext _context;
        
        public FavoritePostsRepository(BlogsDbContext context)
        {
            _context = context;
        }

        public async Task<CreateFavoritePostVm> CreateFavoritePost(FavoritePost favoritePost)
        {
            var createFavoritePostVm = new CreateFavoritePostVm();
            
            var exist = await _context.FavoritePosts
                .SingleOrDefaultAsync(f => f.PostId == favoritePost.PostId && f.UserId == favoritePost.UserId);
            if (exist == null)
            {
                await _context.FavoritePosts.AddAsync(favoritePost);
                createFavoritePostVm.type = "AddFavorite";
            }
            else
            {
                _context.FavoritePosts.Remove(exist);
                createFavoritePostVm.type = "RemoveFavorite";
            }
            await _context.SaveChangesAsync();

            return createFavoritePostVm;
        }
    }
}