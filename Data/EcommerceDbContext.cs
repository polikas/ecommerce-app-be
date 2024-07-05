using Microsoft.EntityFrameworkCore;
using EcommerceApp.Models;

namespace EcommerceApp.Data
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

            //SEED data to Products table
            modelBuilder.Entity<Product>()
                .HasData(
            new
            {
                ProductId = 1,
                ProductName = "Sugar",
                ProductPrice = 4.99M,
                ProductQuantity = 3,
                ProductShippingCost = 5.99M,
                ProductTotalCost = 17.99M,
                ProductEstimatedArrivalDate = new DateTime(2024, 8, 19)
            },
            new
            {
                ProductId = 2,
                ProductName = "Duck",
                ProductPrice = 7.99M,
                ProductQuantity = 1,
                ProductShippingCost = 3.99M,
                ProductTotalCost = 18.99M,
                ProductEstimatedArrivalDate = new DateTime(2019, 4, 26)
            },
            // new
            // {
            //     ProductId = 3,
            //     ProductName = "Pork",
            //     ProductPrice = 6.99M,
            //     ProductQuantity = 8,
            //     ProductShippingCost = 9.99M,
            //     ProductTotalCost = 20.99M,
            //     ProductEstimatedArrivalDate = new DateTime(2021, 2, 14)
            // },
            // new
            // {
            //     ProductId = 4,
            //     ProductName = "Chicken",
            //     ProductPrice = 2.99M,
            //     ProductQuantity = 10,
            //     ProductShippingCost = 12.99M,
            //     ProductTotalCost = 25.99M,
            //     ProductEstimatedArrivalDate = new DateTime(2023, 7, 5)
            // },
            new
            {
                ProductId = 5,
                ProductName = "Beef",
                ProductPrice = 10.99M,
                ProductQuantity = 2,
                ProductShippingCost = 6.99M,
                ProductTotalCost = 17.99M,
                ProductEstimatedArrivalDate = new DateTime(2018, 12, 1)
            });
        }
    }
}
