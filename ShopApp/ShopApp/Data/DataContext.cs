using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
