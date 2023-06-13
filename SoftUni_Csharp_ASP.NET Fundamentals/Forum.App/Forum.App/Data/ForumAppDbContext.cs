using Forum.App.Data.Configuration;
using Forum.App.Data.Models.Post;
using Microsoft.EntityFrameworkCore;

namespace Forum.App.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) : base(options)
        {                
        }

        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
  