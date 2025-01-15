using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mapis.Migrations
{
    /// <inheritdoc />
    public partial class initializingdb9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberType",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberType",
                table: "Applicants");
        }
    }
}
