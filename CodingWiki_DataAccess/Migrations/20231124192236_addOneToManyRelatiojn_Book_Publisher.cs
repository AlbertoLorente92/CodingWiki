using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addOneToManyRelatiojn_Book_Publisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 1,
                column: "Publisher_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 2,
                column: "Publisher_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 3,
                column: "Publisher_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 4,
                column: "Publisher_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 5,
                column: "Publisher_id",
                value: 3);

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Publisher_Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, null, "tryme1" },
                    { 2, null, "tryme2" },
                    { 3, null, "tryme3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publisher_id",
                table: "Books",
                column: "Publisher_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_Publisher_id",
                table: "Books",
                column: "Publisher_id",
                principalTable: "Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_Publisher_id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Publisher_id",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Publisher_id",
                table: "Books");
        }
    }
}
