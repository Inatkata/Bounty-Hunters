using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BountyHunters.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BountyHunters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CaptureCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BountyHunters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Criminals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CrimeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bounty = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaptureDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criminals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateAchieved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BountyHunterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_BountyHunters_BountyHunterId",
                        column: x => x.BountyHunterId,
                        principalTable: "BountyHunters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Captures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BountyHunterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriminalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaptureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Captures_BountyHunters_BountyHunterId",
                        column: x => x.BountyHunterId,
                        principalTable: "BountyHunters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Captures_Criminals_CriminalId",
                        column: x => x.CriminalId,
                        principalTable: "Criminals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BountyHunters",
                columns: new[] { "Id", "Bio", "Name", "Rank" },
                values: new object[] { new Guid("763bb5a4-65ca-445f-adee-846098ca0b57"), "New bounty hunter", "Alice Tracker", "Novice" });

            migrationBuilder.InsertData(
                table: "BountyHunters",
                columns: new[] { "Id", "Bio", "CaptureCount", "Name", "Rank" },
                values: new object[] { new Guid("8f8651c0-7c6c-4e6b-81d7-dbecd1e433bd"), "Seasoned hunter.", 10, "Bob Hunter", "Expert" });

            migrationBuilder.InsertData(
                table: "BountyHunters",
                columns: new[] { "Id", "Bio", "Name", "Rank" },
                values: new object[] { new Guid("9b1d56b1-f46d-4225-8976-c9c70bff5801"), "A new bounty hunter ready for action.", "John Tracker", "Novice" });

            migrationBuilder.InsertData(
                table: "BountyHunters",
                columns: new[] { "Id", "Bio", "CaptureCount", "Name", "Rank" },
                values: new object[] { new Guid("fe4401e8-927d-4ed4-92ee-414b00904977"), "Experienced bounty hunter with countless captures.", 8, "Jane Swift", "Expert" });

            migrationBuilder.InsertData(
                table: "Criminals",
                columns: new[] { "Id", "Bounty", "CaptureDate", "CrimeType", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("6de37a14-f172-420b-a87a-075d12d6d799"), 5000m, null, "Bank Robbery", "John Doe", "At Large" },
                    { new Guid("dddad914-41a0-4525-a4c3-520b74310dfd"), 3000m, null, "Fraud", "Jane Smith", "At Large" },
                    { new Guid("e449bd86-5d5e-49b9-8c5e-5bc882b440b7"), 10000m, null, "Hacking", "Eve Rogue", "At Large" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_BountyHunterId",
                table: "Achievements",
                column: "BountyHunterId");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_BountyHunterId",
                table: "Captures",
                column: "BountyHunterId");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_CriminalId",
                table: "Captures",
                column: "CriminalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Captures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BountyHunters");

            migrationBuilder.DropTable(
                name: "Criminals");
        }
    }
}
