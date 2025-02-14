using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mapis.Migrations
{
    /// <inheritdoc />
    public partial class addedtitletociltuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CiltUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "CiltUser");
        }
    }
}
