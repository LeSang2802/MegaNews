using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaNews.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrltoTblAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "tblAccount",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "tblAccount");
        }
    }
}
