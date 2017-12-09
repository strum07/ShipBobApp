using Microsoft.EntityFrameworkCore;
using ShipBobApp.Models;

namespace ShipBobApp.Data
{
    public class ShipBobAppContext : DbContext
    {
        public ShipBobAppContext (DbContextOptions<ShipBobAppContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Order>().ToTable("Order");
          
        }
    }
}
