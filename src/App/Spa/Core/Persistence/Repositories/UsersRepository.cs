using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.ViewModels;
using AdisBlog.Core.Persistence.Dtos;
using AdisBlog.Data;
using AdisBlog.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdisBlog.Core.Persistence.Repositories
{
    public class UsersRepository
    {
        private readonly BlogsDbContext _context;
        private readonly IMapper _mapper;
        
        public UsersRepository(BlogsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public User FindUserLogin(string username)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username);
        }

        public async Task<GetUserPostsVm> GetUserPosts(string username)
        {
            return await _context.Users
                .Include(u => u.Posts)
                .Select(u => new GetUserPostsVm
                {
                    Username = u.Username,
                    Posts = u.Posts
                })
                .SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IEnumerable<FavoritePostDto>> GetUserFavoritePosts(string username)
        {
            var user = FindUserLogin(username);
           
            var favoritedPostIds = await _context.FavoritePosts.Where(fp => fp.UserId == user.Id)
                .Select(fp => fp.PostId)
                .ToListAsync();

            var posts = await _context.Posts
                .Where(p => favoritedPostIds.Contains(p.Id))
                .Select(p => new FavoritePostDto()
                {
                    Body = p.Body,
                    Id = p.Id,
                    Title = p.Title,
                    Username = p.User.Username
                })
                .ToListAsync();

            return posts;
        }
    }
}