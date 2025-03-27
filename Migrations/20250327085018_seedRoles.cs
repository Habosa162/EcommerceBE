using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1457b5bf-5be2-45bb-9974-997ab3144687", "1", "Admin", "ADMIN" },
                    { "1668a866-8730-478b-bc4b-b4ea5b10732e", "2", "Merchant", "MERCHANT" },
                    { "f34f3809-401d-481a-b85d-9b8d9ca55e34", "3", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1457b5bf-5be2-45bb-9974-997ab3144687");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1668a866-8730-478b-bc4b-b4ea5b10732e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f34f3809-401d-481a-b85d-9b8d9ca55e34");
        }
    }
}
