using FriendlyBoard.Server.Data;
using FriendlyBoard.Server.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FriendlyBoard.Server.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ThreadsController : ControllerBase {
    private readonly BoardDbContext context;

    public ThreadsController(BoardDbContext context) {
      this.context = context;
    }

    [HttpGet]
    public IActionResult Get() =>
      Ok(context.Threads.ToList());

    [HttpGet("{id}", Name = "GetThread")]
    public IActionResult Get(int id) {
      var thread = context.Threads.Include(t => t.Posts)
        .SingleOrDefault(t => t.ThreadId == id);
      if (thread is null) {
        return NotFound();
      }
      return Ok(thread);
    }

    [HttpPost]
    public IActionResult Post([FromBody]PostRequest request) {
      var newThread = new Thread {
        CreatedAt = DateTime.Now,
        CreatedUserId = request.UserId,
        Title = request.Title,
        Comment = request.Comment
      };
      context.Threads.Add(newThread);
      context.SaveChanges();
      return CreatedAtRoute(
        routeName: "GetThread",
        routeValues: new { id = newThread.ThreadId },
        value: newThread
      );
    }

    public class PostRequest {
      public int UserId { get; set; }
      public string Title { get; set; }
      public string Comment { get; set; }
    }
  }
}