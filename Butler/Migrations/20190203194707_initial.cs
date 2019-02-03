using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Butler.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCommandSets",
                columns: table => new
                {
                    AppCommandSetId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    VoicePrompt = table.Column<string>(maxLength: 2000, nullable: true),
                    Response = table.Column<string>(maxLength: 2000, nullable: true),
                    Key = table.Column<string>(maxLength: 10, nullable: true),
                    Modifier = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCommandSets", x => x.AppCommandSetId);
                });

            migrationBuilder.CreateTable(
                name: "spc.auth.Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spc.auth.Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "spc.auth.Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spc.auth.Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppCommandLinks",
                columns: table => new
                {
                    AppCommandLinkId = table.Column<Guid>(nullable: false),
                    Json = table.Column<string>(nullable: true),
                    AppCommandId = table.Column<Guid>(nullable: false),
                    AppCommandSetId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCommandLinks", x => x.AppCommandLinkId);
                    table.ForeignKey(
                        name: "FK_AppCommandLinks_AppCommandSets_AppCommandSetId",
                        column: x => x.AppCommandSetId,
                        principalTable: "AppCommandSets",
                        principalColumn: "AppCommandSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spc.auth.UsersToRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spc.auth.UsersToRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_spc.auth.UsersToRoles_spc.auth.Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "spc.auth.Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spc.auth.UsersToRoles_spc.auth.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "spc.auth.Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCommandLinks_AppCommandSetId",
                table: "AppCommandLinks",
                column: "AppCommandSetId");

            migrationBuilder.CreateIndex(
                name: "IX_spc.auth.UsersToRoles_RoleId",
                table: "spc.auth.UsersToRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCommandLinks");

            migrationBuilder.DropTable(
                name: "spc.auth.UsersToRoles");

            migrationBuilder.DropTable(
                name: "AppCommandSets");

            migrationBuilder.DropTable(
                name: "spc.auth.Roles");

            migrationBuilder.DropTable(
                name: "spc.auth.Users");
        }
    }
}
