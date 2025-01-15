using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mapis.Migrations
{
    /// <inheritdoc />
    public partial class initializingdb8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CILTUserAuths_CiltUser_CILTUserId",
                table: "CILTUserAuths");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisterEvents_CiltUser_CILTUserId",
                table: "RegisterEvents");

            migrationBuilder.DropIndex(
                name: "IX_RegisterEvents_CILTUserId",
                table: "RegisterEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CiltUser",
                table: "CiltUser");

            migrationBuilder.DropColumn(
                name: "CILTUserId",
                table: "CiltUser");

            migrationBuilder.AddColumn<string>(
                name: "CILTUserMemberId",
                table: "RegisterEvents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CILTUserId",
                table: "CILTUserAuths",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "CiltUser",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "CiltUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CiltUser",
                table: "CiltUser",
                column: "MemberId");

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentJobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateJoinedOrganisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceInLogistics = table.Column<int>(type: "int", nullable: false),
                    CurrentMemberShipBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastPaymentYear = table.Column<int>(type: "int", nullable: false),
                    BranchWant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    DateApplied = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicantId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisterEvents_CILTUserMemberId",
                table: "RegisterEvents",
                column: "CILTUserMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_CILTUserAuths_CiltUser_CILTUserId",
                table: "CILTUserAuths",
                column: "CILTUserId",
                principalTable: "CiltUser",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterEvents_CiltUser_CILTUserMemberId",
                table: "RegisterEvents",
                column: "CILTUserMemberId",
                principalTable: "CiltUser",
                principalColumn: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CILTUserAuths_CiltUser_CILTUserId",
                table: "CILTUserAuths");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisterEvents_CiltUser_CILTUserMemberId",
                table: "RegisterEvents");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_RegisterEvents_CILTUserMemberId",
                table: "RegisterEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CiltUser",
                table: "CiltUser");

            migrationBuilder.DropColumn(
                name: "CILTUserMemberId",
                table: "RegisterEvents");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "CiltUser");

            migrationBuilder.AlterColumn<Guid>(
                name: "CILTUserId",
                table: "CILTUserAuths",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "CiltUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "CILTUserId",
                table: "CiltUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CiltUser",
                table: "CiltUser",
                column: "CILTUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterEvents_CILTUserId",
                table: "RegisterEvents",
                column: "CILTUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CILTUserAuths_CiltUser_CILTUserId",
                table: "CILTUserAuths",
                column: "CILTUserId",
                principalTable: "CiltUser",
                principalColumn: "CILTUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterEvents_CiltUser_CILTUserId",
                table: "RegisterEvents",
                column: "CILTUserId",
                principalTable: "CiltUser",
                principalColumn: "CILTUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
