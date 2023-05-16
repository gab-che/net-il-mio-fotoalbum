using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fotoalbum.Migrations
{
    /// <inheritdoc />
    public partial class DropAuthorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photos_authors_author_id",
                table: "photos");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropIndex(
                name: "IX_photos_author_id",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "photos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "author_id",
                table: "photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_photos_author_id",
                table: "photos",
                column: "author_id");

            migrationBuilder.AddForeignKey(
                name: "FK_photos_authors_author_id",
                table: "photos",
                column: "author_id",
                principalTable: "authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
