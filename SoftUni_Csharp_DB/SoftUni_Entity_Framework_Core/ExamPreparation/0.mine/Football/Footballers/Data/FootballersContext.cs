namespace Footballers.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class FootballersContext : DbContext
    {
        public FootballersContext() { }

        public FootballersContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Footballer> Footballers { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<TeamFootballer> TeamsFootballers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamFootballer>(e =>
            {
                e.HasKey(et => new { et.TeamId, et.FootballerId });
            });
        }
    }
}
