using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace MerchShop.Models
{
    public class MerchShopContext : DbContext
    {
        public MerchShopContext(DbContextOptions<MerchShopContext> options) : base(options)
        {

        }

        public DbSet<Merch> Merch { get; set; } = null!;
        public DbSet<Inventory> Inventory { get; set; } = null!;
        public DbSet<Vendor> Vendors { get; set; } = null!;
        public DbSet<Warehouse> Warehouses { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderLines> Orderlines { get; set; } = null!;
        public DbSet<MerchReview> MerchReviews { get; set; } = null!;
        public DbSet<VendorReview> VendorReviews { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new MerchShopConfiguration(modelBuilder);
        }

    }
}
