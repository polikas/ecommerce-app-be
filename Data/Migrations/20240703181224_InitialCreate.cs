using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderShippingCost = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    OrderTotalAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    OrderEstimatedArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderShippingAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderPhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderPostalCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OrderShippingComments = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductShippingCost = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ProductTotalCost = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ProductEstimatedArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductEstimatedArrivalDate", "ProductName", "ProductPrice", "ProductQuantity", "ProductShippingCost", "ProductTotalCost" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sugar", 4.99m, 3, 5.99m, 17.99m },
                    { 2, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duck", 7.99m, 1, 3.99m, 18.99m },
                    { 3, new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pork", 6.99m, 8, 9.99m, 20.99m },
                    { 4, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicken", 2.99m, 10, 12.99m, 25.99m },
                    { 5, new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beef", 10.99m, 2, 6.99m, 17.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
