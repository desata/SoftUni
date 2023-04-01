namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;
    using System.Collections.Generic;
    using System.Reflection.Emit;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() 
        {
        }

        public TeisterMaskContext(DbContextOptions options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}