using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HolderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CodeName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleCodeName = table.Column<string>(type: "TEXT", nullable: false),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false),
                    RoleDescription = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessLogEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccessCardId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccessClaimId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsEntryAllowed = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLogEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessLogEntries_AccessCards_AccessCardId",
                        column: x => x.AccessCardId,
                        principalTable: "AccessCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessCardRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccessCardId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCardRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessCardRoles_AccessCards_AccessCardId",
                        column: x => x.AccessCardId,
                        principalTable: "AccessCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessCardRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessClaimRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccessClaimId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessClaimRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessClaimRoles_AccessClaims_AccessClaimId",
                        column: x => x.AccessClaimId,
                        principalTable: "AccessClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessClaimRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccessCards",
                columns: new[] { "Id", "DeletedOnUtc", "HolderId", "ModifiedOnUtc" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, new Guid("00000000-0000-0000-0000-000000000001"), null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("00000000-0000-0000-0000-000000000002"), null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, new Guid("00000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.InsertData(
                table: "AccessClaims",
                columns: new[] { "Id", "CodeName", "DeletedOnUtc", "ModifiedOnUtc" },
                values: new object[,]
                {
                    { new Guid("42004200-4200-4200-4200-000000000001"), "Room001Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000002"), "Room002Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000003"), "Room003Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000004"), "Room004Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000005"), "Room005Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000006"), "Room006Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000007"), "Room007Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000008"), "Room008Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000009"), "Room009Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000010"), "Room010Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000011"), "Room011Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000012"), "Room012Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000013"), "Room013Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000014"), "Room014Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000015"), "Room015Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000016"), "Room016Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000017"), "Room017Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000018"), "Room018Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000019"), "Room019Access", null, null },
                    { new Guid("42004200-4200-4200-4200-000000000020"), "Room020Access", null, null },
                    { new Guid("42004200-4200-4200-4200-111111111111"), "ReceptionAccess", null, null },
                    { new Guid("42004200-4200-4200-4200-222222222222"), "MaintenanceAccess", null, null },
                    { new Guid("42004200-4200-4200-4200-333333333333"), "RoyalBuffetHallAccess", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeletedOnUtc", "ModifiedOnUtc", "RoleCodeName", "RoleDescription", "RoleName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Room001", "Access to room 001", "Room 001" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), null, null, "Room002", "Access to room 002", "Room 002" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), null, null, "Room003", "Access to room 003", "Room 003" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), null, null, "Room004", "Access to room 004", "Room 004" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), null, null, "Room005", "Access to room 005", "Room 005" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), null, null, "Room006", "Access to room 006", "Room 006" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), null, null, "Room007", "Access to room 007", "Room 007" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), null, null, "Room008", "Access to room 008", "Room 008" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), null, null, "Room009", "Access to room 009", "Room 009" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), null, null, "Room010", "Access to room 010", "Room 010" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), null, null, "Room011", "Access to room 011", "Room 011" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), null, null, "Room012", "Access to room 012", "Room 012" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), null, null, "Room013", "Access to room 013", "Room 013" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), null, null, "Room014", "Access to room 014", "Room 014" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), null, null, "Room015", "Access to room 015", "Room 015" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), null, null, "Room016", "Access to room 016", "Room 016" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), null, null, "Room017", "Access to room 017", "Room 017" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), null, null, "Room018", "Access to room 018", "Room 018" },
                    { new Guid("00000000-0000-0000-0000-000000000019"), null, null, "Room019", "Access to room 019", "Room 019" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), null, null, "Room020", "Access to room 020", "Room 020" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), null, null, "RoyalBuffet", "Access to the royal buffet", "Royal buffet" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), null, null, "Receptionist", "Receptionist role", "Receptionist" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), null, null, "Maintenance", "Maintenance staff", "Maintenance staff" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), null, null, "CleaningStaff", "Cleaning staff", "Cleaning staff" }
                });

            migrationBuilder.InsertData(
                table: "AccessCardRoles",
                columns: new[] { "Id", "AccessCardId", "DeletedOnUtc", "ModifiedOnUtc", "RoleId" },
                values: new object[,]
                {
                    { new Guid("99999999-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), null, null, new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("99999999-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222"), null, null, new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("99999999-3333-3333-3333-333333333333"), new Guid("22222222-2222-2222-2222-222222222222"), null, null, new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "AccessClaimRoles",
                columns: new[] { "Id", "AccessClaimId", "DeletedOnUtc", "ModifiedOnUtc", "RoleId" },
                values: new object[,]
                {
                    { new Guid("42004200-4200-0000-4200-777777777777"), new Guid("42004200-4200-4200-4200-111111111111"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-0000-4200-888888888888"), new Guid("42004200-4200-4200-4200-111111111111"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-0000-4200-999999999999"), new Guid("42004200-4200-4200-4200-111111111111"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999001"), new Guid("42004200-4200-4200-4200-000000000001"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999002"), new Guid("42004200-4200-4200-4200-000000000002"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999003"), new Guid("42004200-4200-4200-4200-000000000003"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999004"), new Guid("42004200-4200-4200-4200-000000000004"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999005"), new Guid("42004200-4200-4200-4200-000000000005"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999006"), new Guid("42004200-4200-4200-4200-000000000006"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999007"), new Guid("42004200-4200-4200-4200-000000000007"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999008"), new Guid("42004200-4200-4200-4200-000000000008"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999009"), new Guid("42004200-4200-4200-4200-000000000009"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999010"), new Guid("42004200-4200-4200-4200-000000000010"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999011"), new Guid("42004200-4200-4200-4200-000000000011"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999012"), new Guid("42004200-4200-4200-4200-000000000012"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999013"), new Guid("42004200-4200-4200-4200-000000000013"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999014"), new Guid("42004200-4200-4200-4200-000000000014"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999015"), new Guid("42004200-4200-4200-4200-000000000015"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999016"), new Guid("42004200-4200-4200-4200-000000000016"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999017"), new Guid("42004200-4200-4200-4200-000000000017"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999018"), new Guid("42004200-4200-4200-4200-000000000018"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999019"), new Guid("42004200-4200-4200-4200-000000000019"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-0000-999999999020"), new Guid("42004200-4200-4200-4200-000000000020"), null, null, new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("42004200-4200-4200-4200-777777777777"), new Guid("42004200-4200-4200-4200-333333333333"), null, null, new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("42004200-4200-4200-4200-888888888888"), new Guid("42004200-4200-4200-4200-222222222222"), null, null, new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("42004200-4200-4200-4200-999999999001"), new Guid("42004200-4200-4200-4200-000000000001"), null, null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("42004200-4200-4200-4200-999999999002"), new Guid("42004200-4200-4200-4200-000000000002"), null, null, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("42004200-4200-4200-4200-999999999003"), new Guid("42004200-4200-4200-4200-000000000003"), null, null, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("42004200-4200-4200-4200-999999999004"), new Guid("42004200-4200-4200-4200-000000000004"), null, null, new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("42004200-4200-4200-4200-999999999005"), new Guid("42004200-4200-4200-4200-000000000005"), null, null, new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("42004200-4200-4200-4200-999999999006"), new Guid("42004200-4200-4200-4200-000000000006"), null, null, new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("42004200-4200-4200-4200-999999999007"), new Guid("42004200-4200-4200-4200-000000000007"), null, null, new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("42004200-4200-4200-4200-999999999008"), new Guid("42004200-4200-4200-4200-000000000008"), null, null, new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("42004200-4200-4200-4200-999999999009"), new Guid("42004200-4200-4200-4200-000000000009"), null, null, new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("42004200-4200-4200-4200-999999999010"), new Guid("42004200-4200-4200-4200-000000000010"), null, null, new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("42004200-4200-4200-4200-999999999011"), new Guid("42004200-4200-4200-4200-000000000011"), null, null, new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("42004200-4200-4200-4200-999999999012"), new Guid("42004200-4200-4200-4200-000000000012"), null, null, new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("42004200-4200-4200-4200-999999999013"), new Guid("42004200-4200-4200-4200-000000000013"), null, null, new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("42004200-4200-4200-4200-999999999014"), new Guid("42004200-4200-4200-4200-000000000014"), null, null, new Guid("00000000-0000-0000-0000-000000000014") },
                    { new Guid("42004200-4200-4200-4200-999999999015"), new Guid("42004200-4200-4200-4200-000000000015"), null, null, new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("42004200-4200-4200-4200-999999999016"), new Guid("42004200-4200-4200-4200-000000000016"), null, null, new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("42004200-4200-4200-4200-999999999017"), new Guid("42004200-4200-4200-4200-000000000017"), null, null, new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("42004200-4200-4200-4200-999999999018"), new Guid("42004200-4200-4200-4200-000000000018"), null, null, new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("42004200-4200-4200-4200-999999999019"), new Guid("42004200-4200-4200-4200-000000000019"), null, null, new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("42004200-4200-4200-4200-999999999020"), new Guid("42004200-4200-4200-4200-000000000020"), null, null, new Guid("00000000-0000-0000-0000-000000000020") },
                    { new Guid("42004200-4200-4200-4200-999999999999"), new Guid("42004200-4200-4200-4200-111111111111"), null, null, new Guid("77777777-7777-7777-7777-777777777777") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessCardRoles_AccessCardId",
                table: "AccessCardRoles",
                column: "AccessCardId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessCardRoles_RoleId",
                table: "AccessCardRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessClaimRoles_AccessClaimId",
                table: "AccessClaimRoles",
                column: "AccessClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessClaimRoles_RoleId",
                table: "AccessClaimRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLogEntries_AccessCardId",
                table: "AccessLogEntries",
                column: "AccessCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessCardRoles");

            migrationBuilder.DropTable(
                name: "AccessClaimRoles");

            migrationBuilder.DropTable(
                name: "AccessLogEntries");

            migrationBuilder.DropTable(
                name: "AccessClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AccessCards");
        }
    }
}
