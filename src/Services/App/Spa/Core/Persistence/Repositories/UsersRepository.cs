using System.Linq;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.ViewModels;
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
                .Select(u => new GetUserPostsVm
                {
                    Username = u.Username,
                    Posts = u.Posts
                })
                .SingleOrDefaultAsync(u => u.Username == username);
        }
        
    }
}