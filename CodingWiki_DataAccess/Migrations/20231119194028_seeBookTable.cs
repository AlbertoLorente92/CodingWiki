using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seeBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "IdBook", "ISBN", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "123812", 10.99m, "Spìder without Duty" },
                    { 2, "11223812", 11.99m, "Fortune of Time" },
                    { 3, "123812", 20.99m, "Fake Sunday" },
                    { 4, "CC123812", 25.99m, "Cooklie Jar" },
                    { 5, "90311223812", 40.99m, "Cloudy Forest" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 5);
        }
    }
}
