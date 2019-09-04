using System.Threading.Tasks;
using AdisBlog.Core.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdisBlog.Controllers
{
    [Route("api")]
    public class TagsController : Controller
    {
        private readonly TagsRepository _repository;

        public TagsController(TagsRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("tags")]
        public async Task<IActionResult> GetTagsByQuery([FromQuery] string query = "")
        {
            var tags = _repository.GetTagsByQuery(query);
            
            return Json(tags);
        }
    }
}