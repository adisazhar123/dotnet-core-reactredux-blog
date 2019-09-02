using System;
using System.Threading.Tasks;
using AdisBlog.Core.Persistence.Repositories;
using AdisBlog.Core.Persistence.Requests;
using AdisBlog.Models;
using AdisBlog.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdisBlog.Controllers
{
    [Authorize(Roles = "user,admin")]
    [Route("api")]
    public class CommentsPostsController : Controller
    {
        private CommentsPostsRepository _repo;
        
        public CommentsPostsController(CommentsPostsRepository repo)
        {
            _repo = repo;
        }
        
        [HttpPost(Route.COMMENTS_CREATE)]
        public async Task<IActionResult> CreateCommentAsync(Guid postId, [FromBody] CreateComment request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var comment = new Comment
            {
                Body = request.Body,
                PostId = postId
            };
            await _repo.CreateCommentAsync(postId, comment);

            return Created(nameof(Route.COMMENTS_CREATE), comment);
        }
        
        [AllowAnonymous]
        [HttpGet("posts/{postId}/comments")]
        public IActionResult GetComments(Guid postId)
        {
            return Json(_repo.GetComments(postId));
        }
    }
}