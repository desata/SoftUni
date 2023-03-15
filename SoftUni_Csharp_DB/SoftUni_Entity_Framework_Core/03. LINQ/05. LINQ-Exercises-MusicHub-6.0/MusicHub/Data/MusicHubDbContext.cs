namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }
        public DbSet<Producer> Producers { get; set; } = null!;
        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Performer> Performers { get; set; } = null!;
        public DbSet<SongPerformer> SongsPerformers { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<Writer> Writers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(sp => new { sp.SongId, sp.PerformerId });
            });
        }
    }
}
