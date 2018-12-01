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

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<User>(entity => {
        entity.Property(user => user.Name).HasMaxLength(20).HasDefaultValue("Anonymous");
        if(environment.IsDevelopment()) {
          entity.HasData(
          /*
           * TODO: Adding Dummy User
           */
          );
        }
      });
      modelBuilder.Entity<Thread>(entity => {
        entity.Property(thread => thread.Title).IsRequired().HasMaxLength(20);
        entity.Property(thread => thread.Comment).IsRequired().HasMaxLength(1024);
        entity.HasOne(thread => thread.CreatedBy);
        entity.HasMany(thread => thread.Posts).WithOne(post => post.Thread);
      });
      modelBuilder.Entity<Post>(entity => {
        entity.Property(post => post.Comment).IsRequired().HasMaxLength(1024);
        entity.HasOne(post => post.PostedBy);
      });
    }
  }
}
