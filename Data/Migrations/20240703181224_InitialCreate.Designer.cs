﻿// <auto-generated />
using System;
using EcommerceApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcommerceApp.Data.Migrations
{
    [DbContext(typeof(EcommerceDbContext))]
    [Migration("20240703181224_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcommerceApp.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("OrderCity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrderCountry")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("OrderEstimatedArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrderLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrderPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrderPostalCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("OrderShippingAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OrderShippingComments")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<decimal>("OrderShippingCost")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("OrderTotalAmount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EcommerceApp.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int>("OrderDetailQuantity")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("EcommerceApp.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<DateTime>("ProductEstimatedArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("ProductPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductShippingCost")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ProductTotalCost")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductEstimatedArrivalDate = new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductName = "Sugar",
                            ProductPrice = 4.99m,
                            ProductQuantity = 3,
                            ProductShippingCost = 5.99m,
                            ProductTotalCost = 17.99m
                        },
                        new
                        {
                            ProductId = 2,
                            ProductEstimatedArrivalDate = new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductName = "Duck",
                            ProductPrice = 7.99m,
                            ProductQuantity = 1,
                            ProductShippingCost = 3.99m,
                            ProductTotalCost = 18.99m
                        },
                        new
                        {
                            ProductId = 3,
                            ProductEstimatedArrivalDate = new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductName = "Pork",
                            ProductPrice = 6.99m,
                            ProductQuantity = 8,
                            ProductShippingCost = 9.99m,
                            ProductTotalCost = 20.99m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductEstimatedArrivalDate = new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductName = "Chicken",
                            ProductPrice = 2.99m,
                            ProductQuantity = 10,
                            ProductShippingCost = 12.99m,
                            ProductTotalCost = 25.99m
                        },
                        new
                        {
                            ProductId = 5,
                            ProductEstimatedArrivalDate = new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductName = "Beef",
                            ProductPrice = 10.99m,
                            ProductQuantity = 2,
                            ProductShippingCost = 6.99m,
                            ProductTotalCost = 17.99m
                        });
                });

            modelBuilder.Entity("EcommerceApp.Models.OrderDetail", b =>
                {
                    b.HasOne("EcommerceApp.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceApp.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceApp.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
