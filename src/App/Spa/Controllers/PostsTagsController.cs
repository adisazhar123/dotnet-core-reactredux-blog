using System.Linq;
using System.Threading.Tasks;
using AdisBlog.Core.Domain.ViewModels;
using AdisBlog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdisBlog.Controllers
{
    [Route("api")]
    public class PostsTagsController : Controller
    {
        private readonly BlogsDbContext _context;

        public PostsTagsController(BlogsDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("tags")]
        public async Task<IActionResult> GetTagsByQuery([FromQuery] string query = "")
        {
            query = query == null ? "" : query;
            var tags = await _context.Tags.Where(t => t.Title.Contains(query))
                .Select(t => new GetTagsByQueryVm
                {
                    Label = t.Title,
                    Value = t.Id
                }).ToListAsync();

            return Json(tags);
        }
    }
}