using Microsoft.EntityFrameworkCore;
using ShopBridgeDAL.Inventory.Models;

namespace ShopBridgeDAL.Inventory.Models
{
    public class ShopBridgeDbContext : DbContext
    {
        public ShopBridgeDbContext(DbContextOptions<ShopBridgeDbContext> options) : base(options) { Database.SetCommandTimeout(1000); }
        protected override void OnModelCreating(ModelBuilder foModelBuilder)
        {
            foModelBuilder.Entity<Inventory>().HasNoKey();
        }
    }
}
