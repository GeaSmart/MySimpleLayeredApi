using Microsoft.EntityFrameworkCore;
using MySimpleLayeredApi.Entities;

namespace MySimpleLayeredApi.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
