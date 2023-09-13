using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    public partial class Mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameAccounts",
                columns: table => new
                {
                    GameAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAccounts", x => x.GameAccountId);
                });

            migrationBuilder.CreateTable(
                name: "GameClasss",
                columns: table => new
                {
                    GameClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionGameClass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameClasss", x => x.GameClassId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacters",
                columns: table => new
                {
                    GameCharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameCharacterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscriptionGameChar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacters", x => x.GameCharacterId);
                    table.ForeignKey(
                        name: "FK_GameCharacters_GameAccounts_GameAccountId",
                        column: x => x.GameAccountId,
                        principalTable: "GameAccounts",
                        principalColumn: "GameAccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCharacters_GameClasss_GameClassId",
                        column: x => x.GameClassId,
                        principalTable: "GameClasss",
                        principalColumn: "GameClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameAccounts_Email",
                table: "GameAccounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacters_GameAccountId",
                table: "GameCharacters",
                column: "GameAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacters_GameClassId",
                table: "GameCharacters",
                column: "GameClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCharacters");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "GameAccounts");

            migrationBuilder.DropTable(
                name: "GameClasss");
        }
    }
}
