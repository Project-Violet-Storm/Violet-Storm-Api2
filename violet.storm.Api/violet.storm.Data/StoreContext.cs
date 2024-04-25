using violet.storm.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using violet.storm.Data;
using violet.storm.Domain.Orders;

namespace violet.storm.data {
    public class StoreContext : DbContext{
        public StoreContext(DbContextOptions<StoreContext>options) : base(options) {}
        public DbSet<Item> Items {get; set; }
        public DbSet<Order> Orders {get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
                DbInitializer.Initialize(builder);
            }

    }
}