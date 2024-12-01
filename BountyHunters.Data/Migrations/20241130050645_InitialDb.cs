using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BountyHunters.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
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
                    CaptureCount = table.Column<int>(type: "int", nullable: false)
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
                    BountyHunterId = table.Column<int>(type: "int", nullable: false),
                    BountyHunterId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_BountyHunters_BountyHunterId1",
                        column: x => x.BountyHunterId1,
                        principalTable: "BountyHunters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Captures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BountyHunterId = table.Column<int>(type: "int", nullable: false),
                    CriminalId = table.Column<int>(type: "int", nullable: false),
                    CaptureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BountyHunterId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriminalId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Captures_BountyHunters_BountyHunterId1",
                        column: x => x.BountyHunterId1,
                        principalTable: "BountyHunters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Captures_Criminals_CriminalId1",
                        column: x => x.CriminalId1,
                        principalTable: "Criminals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Criminals",
                columns: new[] { "Id", "Bounty", "CaptureDate", "CrimeType", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("559c6554-e160-4003-a977-f09daec53c83"), 5000m, null, "Bank Robbery", "John Doe", "At Large" },
                    { new Guid("77341690-0fec-40dc-af8f-1347562f1c84"), 10000m, null, "Hacking", "Eve Rogue", "At Large" },
                    { new Guid("c699b3bd-7bb7-4d82-a2ba-7d8ff2ca65df"), 3000m, null, "Fraud", "Jane Smith", "At Large" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_BountyHunterId1",
                table: "Achievements",
                column: "BountyHunterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_BountyHunterId1",
                table: "Captures",
                column: "BountyHunterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_CriminalId1",
                table: "Captures",
                column: "CriminalId1");
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
