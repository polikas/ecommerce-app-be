using Microsoft.EntityFrameworkCore;
using ecommerce.Models;

namespace ecommerce.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships for OrderDetails table
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => od.OrderDetailId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId);


            //configure Order table properties
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderShippingAddress)
                .HasMaxLength(100);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderFirstName)
                .HasMaxLength(50);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderLastName)
                .HasMaxLength(50);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderEmail)
                .HasMaxLength(50);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderPhoneNumber)
                .HasMaxLength(50);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderCountry)
                .HasMaxLength(50);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderCity)
                .HasMaxLength(50);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderPostalCode)
                .HasMaxLength(30);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderShippingComments)
                .HasMaxLength(400);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderShippingCost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderTotalAmount)
                .HasPrecision(10, 2);


            //configure Product table properties
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductShippingCost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductTotalCost)
                .HasPrecision(10, 2);
        }
    }
}
