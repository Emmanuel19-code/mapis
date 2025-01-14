using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mapis.Migrations
{
    /// <inheritdoc />
    public partial class initializingdb5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterEvents",
                columns: table => new
                {
                    EventRegistrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CILTUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterEvents", x => x.EventRegistrationId);
                    table.ForeignKey(
                        name: "FK_RegisterEvents_CiltUser_CILTUserId",
                        column: x => x.CILTUserId,
                        principalTable: "CiltUser",
                        principalColumn: "CILTUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisterEvents_CILTUserId",
                table: "RegisterEvents",
                column: "CILTUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterEvents_EventId",
                table: "RegisterEvents",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterEvents");
        }
    }
}
