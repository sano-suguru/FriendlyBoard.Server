using System;

namespace FriendlyBoard.Server {
  public interface IClock {
    DateTime Now { get; }
  }

  public class SystemClock : IClock {
    public DateTime Now => DateTime.Now;
  }
}
