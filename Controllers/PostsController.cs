using FriendlyBoard.Server.Data;
using FriendlyBoard.Server.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FriendlyBoard.Server.Controllers {
  [Route("api/[controller]/{threadId}")]
  [ApiController]
  public class PostsController : ControllerBase {
    private readonly BoardDbContext context;

    public PostsController(BoardDbContext context) {
      this.context = context;
    }

    [HttpPost]
    IActionResult Post(int threadId, [FromBody]Post post) {
      var thread = context.Threads.SingleOrDefault(x => x.ThreadId == threadId);
      if (thread is null) {
        return NotFound();
      }
      thread.Posts.Add(post);
      context.SaveChanges();
      return NoContent();
    }
  }
}