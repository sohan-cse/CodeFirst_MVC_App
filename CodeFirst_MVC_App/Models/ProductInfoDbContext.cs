using Microsoft.EntityFrameworkCore;

namespace CodeFirst_MVC_App.Models
{
    public class ProductInfoDbContext : DbContext
    {
        public ProductInfoDbContext(DbContextOptions options):base(options) { }
        public DbSet<Product> Products { get; set; }
        
    }
}
