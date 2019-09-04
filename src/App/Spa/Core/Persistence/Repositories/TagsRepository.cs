using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.ViewModels;
using AdisBlog.Data;
using Microsoft.EntityFrameworkCore;

namespace AdisBlog.Core.Persistence.Repositories
{
    public class TagsRepository
    {
        private readonly BlogsDbContext _context;
        
        public TagsRepository(BlogsDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetTagsByQueryVm>> GetTagsByQuery(string query)
        {
            query = query == null ? "" : query;
            return await _context.Tags.Where(t => t.Title.Contains(query))
                .Select(t => new GetTagsByQueryVm
                {
                    Label = t.Title,
                    Value = t.Id
                }).ToListAsync();
        }
    }
}