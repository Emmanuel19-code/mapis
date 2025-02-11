using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mapis.Migrations
{
    /// <inheritdoc />
    public partial class updatingdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CILTUserAuths",
                table: "CILTUserAuths");

            migrationBuilder.DropIndex(
                name: "IX_CILTUserAuths_CILTUserId",
                table: "CILTUserAuths");

            migrationBuilder.DropColumn(
                name: "CILTUserAuthId",
                table: "CILTUserAuths");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CILTUserAuths",
                table: "CILTUserAuths",
                column: "CILTUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CILTUserAuths",
                table: "CILTUserAuths");

            migrationBuilder.AddColumn<Guid>(
                name: "CILTUserAuthId",
                table: "CILTUserAuths",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CILTUserAuths",
                table: "CILTUserAuths",
                column: "CILTUserAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_CILTUserAuths_CILTUserId",
                table: "CILTUserAuths",
                column: "CILTUserId",
                unique: true);
        }
    }
}
