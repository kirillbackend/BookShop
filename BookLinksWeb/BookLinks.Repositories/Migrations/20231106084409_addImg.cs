using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLinks.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class addImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageContent",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginalFileName",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServerFileName",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContent",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "OriginalFileName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ServerFileName",
                table: "Books");
        }
    }
}
