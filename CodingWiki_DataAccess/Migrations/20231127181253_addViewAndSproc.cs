using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addViewAndSproc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW dbo.GetMainBookDetails
                AS
                SELECT m.isbn,m.title,m.price from dbo.books m");
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW dbo.GetAllBookDetails
                AS
                SELECT * from dbo.books m");
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.getBookDetailById
                @bookId int
                AS
                    SET NOCOUNT ON;
                    SELECT * FROM dbo.Books b
                    WHERE b.IdBook = @bookId
                GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW dbo.GetMainBookDetails");
            migrationBuilder.Sql(@"DROP VIEW dbo.GetAllBookDetails");
            migrationBuilder.Sql(@"DROP PROCEDURE dbo.getBookDetailById");
        }
    }
}
