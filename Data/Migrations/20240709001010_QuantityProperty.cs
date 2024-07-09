using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class QuantityProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderTotalAmount",
                table: "Orders",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "OrderShippingCost",
                table: "Orders",
                newName: "ShippingCost");

            migrationBuilder.RenameColumn(
                name: "OrderShippingComments",
                table: "Orders",
                newName: "ShippingComments");

            migrationBuilder.RenameColumn(
                name: "OrderShippingAddress",
                table: "Orders",
                newName: "ShippingAddress");

            migrationBuilder.RenameColumn(
                name: "OrderPostalCode",
                table: "Orders",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "OrderPhoneNumber",
                table: "Orders",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "OrderLastName",
                table: "Orders",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "OrderFirstName",
                table: "Orders",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "OrderEstimatedArrivalDate",
                table: "Orders",
                newName: "EstimatedArrivalDate");

            migrationBuilder.RenameColumn(
                name: "OrderEmail",
                table: "Orders",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "OrderCountry",
                table: "Orders",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "OrderCity",
                table: "Orders",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "OrderDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "OrderDetails",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Orders",
                newName: "OrderTotalAmount");

            migrationBuilder.RenameColumn(
                name: "ShippingCost",
                table: "Orders",
                newName: "OrderShippingCost");

            migrationBuilder.RenameColumn(
                name: "ShippingComments",
                table: "Orders",
                newName: "OrderShippingComments");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress",
                table: "Orders",
                newName: "OrderShippingAddress");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Orders",
                newName: "OrderPostalCode");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Orders",
                newName: "OrderPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Orders",
                newName: "OrderLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Orders",
                newName: "OrderFirstName");

            migrationBuilder.RenameColumn(
                name: "EstimatedArrivalDate",
                table: "Orders",
                newName: "OrderEstimatedArrivalDate");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Orders",
                newName: "OrderEmail");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Orders",
                newName: "OrderCountry");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Orders",
                newName: "OrderCity");
        }
    }
}
