using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelServiceSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CleanRoomRequestEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RoomNumber = table.Column<int>(type: "INTEGER", maxLength: 999999, nullable: false),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleanRoomRequestEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GlobalGuestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuestFirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GuestLastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GuestRoomNumber = table.Column<int>(type: "INTEGER", maxLength: 999999, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PremiumServiceEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Image = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,4)", nullable: false),
                    RelevantRoleCodeName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumServiceEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomServiceEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,4)", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomServiceEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomServiceOrderEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomServiceOrderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomServiceOrderEntity_GuestEntity_GuestId",
                        column: x => x.GuestId,
                        principalTable: "GuestEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PremiumServiceOrderEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PremiumServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumServiceOrderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PremiumServiceOrderEntity_GuestEntity_GuestId",
                        column: x => x.GuestId,
                        principalTable: "GuestEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PremiumServiceOrderEntity_PremiumServiceEntity_PremiumServiceId",
                        column: x => x.PremiumServiceId,
                        principalTable: "PremiumServiceEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomServiceOrderItemEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(6,4)", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomServiceOrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoomServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    RoomServiceEntityId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomServiceOrderItemEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomServiceOrderItemEntity_RoomServiceEntity_RoomServiceEntityId",
                        column: x => x.RoomServiceEntityId,
                        principalTable: "RoomServiceEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomServiceOrderItemEntity_RoomServiceEntity_RoomServiceId",
                        column: x => x.RoomServiceId,
                        principalTable: "RoomServiceEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomServiceOrderItemEntity_RoomServiceOrderEntity_RoomServiceOrderId",
                        column: x => x.RoomServiceOrderId,
                        principalTable: "RoomServiceOrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PremiumServiceOrderEntity_GuestId",
                table: "PremiumServiceOrderEntity",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumServiceOrderEntity_PremiumServiceId",
                table: "PremiumServiceOrderEntity",
                column: "PremiumServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceOrderEntity_GuestId",
                table: "RoomServiceOrderEntity",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceOrderItemEntity_RoomServiceEntityId",
                table: "RoomServiceOrderItemEntity",
                column: "RoomServiceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceOrderItemEntity_RoomServiceId",
                table: "RoomServiceOrderItemEntity",
                column: "RoomServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceOrderItemEntity_RoomServiceOrderId",
                table: "RoomServiceOrderItemEntity",
                column: "RoomServiceOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleanRoomRequestEntity");

            migrationBuilder.DropTable(
                name: "PremiumServiceOrderEntity");

            migrationBuilder.DropTable(
                name: "RoomServiceOrderItemEntity");

            migrationBuilder.DropTable(
                name: "PremiumServiceEntity");

            migrationBuilder.DropTable(
                name: "RoomServiceEntity");

            migrationBuilder.DropTable(
                name: "RoomServiceOrderEntity");

            migrationBuilder.DropTable(
                name: "GuestEntity");
        }
    }
}
