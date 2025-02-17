using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mapis.Migrations
{
    /// <inheritdoc />
    public partial class update113 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterEvents_CiltUser_CILTUserMemberId",
                table: "RegisterEvents");

            migrationBuilder.DropIndex(
                name: "IX_RegisterEvents_CILTUserMemberId",
                table: "RegisterEvents");

            migrationBuilder.DropColumn(
                name: "CILTUserMemberId",
                table: "RegisterEvents");

            migrationBuilder.AlterColumn<string>(
                name: "CILTUserId",
                table: "RegisterEvents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterEvents_CILTUserId",
                table: "RegisterEvents",
                column: "CILTUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterEvents_CiltUser_CILTUserId",
                table: "RegisterEvents",
                column: "CILTUserId",
                principalTable: "CiltUser",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterEvents_CiltUser_CILTUserId",
                table: "RegisterEvents");

            migrationBuilder.DropIndex(
                name: "IX_RegisterEvents_CILTUserId",
                table: "RegisterEvents");

            migrationBuilder.AlterColumn<Guid>(
                name: "CILTUserId",
                table: "RegisterEvents",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CILTUserMemberId",
                table: "RegisterEvents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterEvents_CILTUserMemberId",
                table: "RegisterEvents",
                column: "CILTUserMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterEvents_CiltUser_CILTUserMemberId",
                table: "RegisterEvents",
                column: "CILTUserMemberId",
                principalTable: "CiltUser",
                principalColumn: "MemberId");
        }
    }
}
