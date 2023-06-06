using Microsoft.EntityFrameworkCore;


namespace EFCore.Infrastructure.Model
{
    public class WebShopDBContext : DbContext
    {
        public WebShopDBContext(DbContextOptions<WebShopDBContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNote> ProductNotes { get; set; }
    }
}