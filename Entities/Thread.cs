using System;
using System.Collections.Generic;

namespace FriendlyBoard.Server.Entities {
  public class Thread {
    public int ThreadId { get; set; }
    public DateTime CreatedAt { get; set; }
    public User CreatedBy { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }

    public IList<Post> Posts { get; set; }
  }
}
