using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mapis.Migrations
{
    /// <inheritdoc />
    public partial class initializingdb7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastPassordChange",
                table: "CiltUser");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPassordChange",
                table: "CILTUserAuths",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastPassordChange",
                table: "CILTUserAuths");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPassordChange",
                table: "CiltUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
