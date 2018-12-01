using System;

namespace FriendlyBoard.Server.Entities {
  public class Post {
    public int PostId { get; set; }
    public DateTime PostedAt { get; set; }
    public User PostedBy { get; set; }
    public string Comment { get; set; }

    public int ThreadId { get; set; }
    public Thread Thread { get; set; }
  }
}