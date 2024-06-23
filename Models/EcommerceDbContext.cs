using Microsoft.EntityFrameworkCore;

namespace ecommerce.Models
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
            // Configure relationships
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

            modelBuilder.Entity<Order>()
             .Property(o => o.OrderShippingCost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderTotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductShippingCost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductTotalCost)
                .HasPrecision(18, 2);
        }
    }
}
