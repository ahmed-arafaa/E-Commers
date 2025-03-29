using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_commerce_InfraStrucure.Migrations
{
    /// <inheritdoc />
    public partial class afterdataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "ahmed@gmail.com", "Ahmed", "01112840812" },
                    { 2, "arafa@gmail.com", "ARAFA", "0224457386" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "High-performance laptop", "Laptop", 1200.99, 15 },
                    { 2, "Latest model smartphone", "Smartphone", 799.99000000000001, 25 },
                    { 3, "Noise-canceling headphones", "Headphones", 199.99000000000001, 50 },
                    { 4, "Mechanical keyboard", "Keyboard", 99.989999999999995, 30 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 28, 10, 5, 43, 830, DateTimeKind.Local).AddTicks(3699), "Pending", 200.0 },
                    { 2, 2, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 500.0 }
                });

            migrationBuilder.InsertData(
                table: "OrderedProduct",
                columns: new[] { "OrderId", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderedProduct",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
