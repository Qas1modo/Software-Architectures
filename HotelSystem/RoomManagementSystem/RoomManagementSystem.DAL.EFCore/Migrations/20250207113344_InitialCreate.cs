using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoomManagementSystem.DAL.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    BedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomState = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservationType = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedCount", "Capacity", "CreatedAt", "Description", "Name", "Price", "RoomState" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spacious room with city view and king-size bed", "Deluxe Room 101", 199.99m, 0 },
                    { 2, 2, 4, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Large suite with two bedrooms and living area", "Family Suite 201", 349.99m, 0 },
                    { 3, 2, 2, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comfortable room with twin beds", "Standard Room 102", 149.99m, 2 },
                    { 4, 1, 2, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luxury suite with private balcony", "Executive Suite 301", 299.99m, 3 },
                    { 5, 1, 1, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Budget-friendly room with basic amenities", "Economy Room 103", 99.99m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CreatedAt", "EndDate", "ReservationType", "RoomId", "StartDate", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 5, new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 7, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
