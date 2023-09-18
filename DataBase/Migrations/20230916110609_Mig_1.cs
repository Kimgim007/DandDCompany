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
                name: "GameRooms",
                columns: table => new
                {
                    GameRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameRoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminRoomEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRooms", x => x.GameRoomId);
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

            migrationBuilder.CreateTable(
                name: "GameAccountGameRooms",
                columns: table => new
                {
                    GameAccountGameRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameCharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Pass = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAccountGameRooms", x => x.GameAccountGameRoomId);
                    table.ForeignKey(
                        name: "FK_GameAccountGameRooms_GameAccounts_GameAccountId",
                        column: x => x.GameAccountId,
                        principalTable: "GameAccounts",
                        principalColumn: "GameAccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameAccountGameRooms_GameCharacters_GameCharacterId",
                        column: x => x.GameCharacterId,
                        principalTable: "GameCharacters",
                        principalColumn: "GameCharacterId");
                    table.ForeignKey(
                        name: "FK_GameAccountGameRooms_GameRooms_GameRoomId",
                        column: x => x.GameRoomId,
                        principalTable: "GameRooms",
                        principalColumn: "GameRoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameAccountGameRooms_GameAccountId",
                table: "GameAccountGameRooms",
                column: "GameAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GameAccountGameRooms_GameCharacterId",
                table: "GameAccountGameRooms",
                column: "GameCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_GameAccountGameRooms_GameRoomId",
                table: "GameAccountGameRooms",
                column: "GameRoomId");

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
                name: "GameAccountGameRooms");

            migrationBuilder.DropTable(
                name: "GameCharacters");

            migrationBuilder.DropTable(
                name: "GameRooms");

            migrationBuilder.DropTable(
                name: "GameAccounts");

            migrationBuilder.DropTable(
                name: "GameClasss");
        }
    }
}
