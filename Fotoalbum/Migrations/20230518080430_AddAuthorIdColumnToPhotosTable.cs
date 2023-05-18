using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fotoalbum.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorIdColumnToPhotosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "author_id",
                table: "photos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "author_id",
                table: "photos");
        }
    }
}
