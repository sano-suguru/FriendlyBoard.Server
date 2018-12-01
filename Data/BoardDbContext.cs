using FriendlyBoard.Server.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FriendlyBoard.Server.Data {
  public class BoardDbContext : DbContext {
    private readonly IHostingEnvironment environment;

    public BoardDbContext(
      DbContextOptions<BoardDbContext> options,
      IHostingEnvironment environment
    ) : base(options) {
      this.environment = environment;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Thread> Threads { get; set; }
    public DbSet<Post> Posts { get; set; }
  }
}
