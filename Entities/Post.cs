using System;

namespace FriendlyBoard.Server.Entities {
  public class Post {
    public int PostId { get; set; }
    public DateTime PostedAt { get; set; }
    public User PostedBy { get; set; }
    public string Comment { get; set; }

    public int BoardId { get; set; }
    public Board Board { get; set; }
  }
}