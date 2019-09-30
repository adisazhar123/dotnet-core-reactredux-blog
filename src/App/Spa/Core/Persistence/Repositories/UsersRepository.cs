using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.ViewModels;
using AdisBlog.Core.Persistence.Dtos;
using AdisBlog.Core.Persistence.Requests;
using AdisBlog.Data;
using AdisBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace AdisBlog.Core.Persistence.Repositories
{
    public class UsersRepository
    {
        private readonly BlogsDbContext _context;
        
        public UsersRepository(BlogsDbContext context)
        {
            _context = context;
        }
        public User FindUserLogin(string username)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username);
        }

        public async Task<GetUserPostsVm> GetUserPosts(string username)
        {
            return await _context.Users
                .Include(u => u.Posts)
                .Include(u => u.Followings)
                .Select(u => new GetUserPostsVm
                {
                    Username = u.Username,
                    Posts = u.Posts,
                    UserId = u.Id,
                    Followings = u.Followings
                })
                .SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task<List<Following>> GetMyFollowingsAsync(Guid userId)
        {
            return await _context.Followings
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<FavoritePostDto>> GetUserFavoritePosts(string username)
        {
            var user = FindUserLogin(username);
           
            var favoritedPostIds = await _context.FavoritePosts.Where(fp => fp.UserId == user.Id)
                .Select(fp => fp.PostId)
                .ToListAsync();

            var posts = await _context.Posts
                .Where(p => favoritedPostIds.Contains(p.Id))
                .Select(p => new FavoritePostDto
                {
                    Body = p.Body,
                    Id = p.Id,
                    Title = p.Title,
                    Username = p.User.Username
                })
                .ToListAsync();

            return posts;
        }

        public async Task<RegisterDto> RegisterAsync(Register register)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Username == register.Username);

            if (user != null) return new RegisterDto{User = null, Success = false, Message = "An account with the specified username exist."};
            
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(register.Password);
            
            user = new User
            {
                Username = register.Username,
                Password = hashedPassword,
                Role = User.RoleUser
            };
            
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return new RegisterDto
            {
                User = user,
                Success = true,
                Message = "Account registration successful."
            };
        }

        public async Task<User> FollowUserAsync(Guid currentUserId, Guid followingUserId)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(user => user.Id == currentUserId);
            currentUser.Followings = new List<Following>();
            var followingUser = new Following
            {
                UserId = currentUserId,
                FollowingUserId = followingUserId
            };
            currentUser.Followings.Add(followingUser);
            await _context.SaveChangesAsync();
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == followingUserId);
        }
    }
}