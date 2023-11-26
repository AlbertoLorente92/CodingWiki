using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class renamingTablesCorretly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Publisher",
                table: "Fluent_Publisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books_fluent",
                table: "Books_fluent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors_fluent",
                table: "Authors_fluent");

            migrationBuilder.RenameTable(
                name: "Fluent_Publisher",
                newName: "Fluent_Publishers");

            migrationBuilder.RenameTable(
                name: "Books_fluent",
                newName: "Fluent_Books");

            migrationBuilder.RenameTable(
                name: "Authors_fluent",
                newName: "Fluent_Authors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Publishers",
                table: "Fluent_Publishers",
                column: "Publisher_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Books",
                table: "Fluent_Books",
                column: "IdBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Authors",
                table: "Fluent_Authors",
                column: "Author_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Publishers",
                table: "Fluent_Publishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Books",
                table: "Fluent_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Authors",
                table: "Fluent_Authors");

            migrationBuilder.RenameTable(
                name: "Fluent_Publishers",
                newName: "Fluent_Publisher");

            migrationBuilder.RenameTable(
                name: "Fluent_Books",
                newName: "Books_fluent");

            migrationBuilder.RenameTable(
                name: "Fluent_Authors",
                newName: "Authors_fluent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Publisher",
                table: "Fluent_Publisher",
                column: "Publisher_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books_fluent",
                table: "Books_fluent",
                column: "IdBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors_fluent",
                table: "Authors_fluent",
                column: "Author_Id");
        }
    }
}
