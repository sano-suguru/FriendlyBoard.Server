using System;
using System.Collections.Generic;

namespace FriendlyBoard.Server.Entities {
  public class Board {
    public int BoardId { get; set; }
    public string Title { get; }
    public string Comment { get; set; }
    public DateTime PostedAt { get; set; }
    public User PostedBy { get; set; }

    public IList<Post> Posts { get; set; }
  }
}
