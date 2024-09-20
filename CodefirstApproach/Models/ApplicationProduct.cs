using Microsoft.EntityFrameworkCore;

namespace CodefirstApproach.Models
{
    public class ApplicationProduct:DbContext
    {
        public ApplicationProduct(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Product> ProductTable { get; set; }
    }
}
