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
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MicrosoftAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MicrosoftAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "GamingSystems",
                columns: table => new
                {
                    GamingSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamingSystemName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingSystems", x => x.GamingSystemId);
                });

            migrationBuilder.CreateTable(
                name: "GameClasss",
                columns: table => new
                {
                    GameClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionGameClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GamingSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameClasss", x => x.GameClassId);
                    table.ForeignKey(
                        name: "FK_GameClasss_GamingSystems_GamingSystemId",
                        column: x => x.GamingSystemId,
                        principalTable: "GamingSystems",
                        principalColumn: "GamingSystemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamingSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_GamingSystems_GamingSystemId",
                        column: x => x.GamingSystemId,
                        principalTable: "GamingSystems",
                        principalColumn: "GamingSystemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscriptionChar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_GameClasss_GameClassId",
                        column: x => x.GameClassId,
                        principalTable: "GameClasss",
                        principalColumn: "GameClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterRooms",
                columns: table => new
                {
                    CharacterRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Pass = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterRooms", x => x.CharacterRoomId);
                    table.ForeignKey(
                        name: "FK_CharacterRooms_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_CharacterRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRooms_CharacterId",
                table: "CharacterRooms",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRooms_RoomId",
                table: "CharacterRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AccountId",
                table: "Characters",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GameClassId",
                table: "Characters",
                column: "GameClassId");

            migrationBuilder.CreateIndex(
                name: "IX_GameClasss_GamingSystemId",
                table: "GameClasss",
                column: "GamingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AccountId",
                table: "Rooms",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_GamingSystemId",
                table: "Rooms",
                column: "GamingSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterRooms");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "GameClasss");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "GamingSystems");
        }
    }
}
