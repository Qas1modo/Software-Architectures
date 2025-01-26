using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
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
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermissionName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    PermissionDescription = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    RoleDescription = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
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
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
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
                name: "AccessCardPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccessCardId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCardPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessCardPermissions_AccessCards_AccessCardId",
                        column: x => x.AccessCardId,
                        principalTable: "AccessCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccessCardPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccessCardRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccessCardId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCardRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessCardRoles_AccessCards_AccessCardId",
                        column: x => x.AccessCardId,
                        principalTable: "AccessCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccessCardRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AccessCards",
                columns: new[] { "Id", "DeletedOnUtc", "ModifiedOnUtc" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "DeletedOnUtc", "ModifiedOnUtc", "PermissionDescription", "PermissionName" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, null, "Gym permission", "Gym" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, null, "Pool permission", "Pool" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), null, null, "Maintenance permission", "Maintenance" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeletedOnUtc", "ModifiedOnUtc", "RoleDescription", "RoleName" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), null, null, "Receptionist role", "Receptionist" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), null, null, "Guest role", "Guest role" }
                });

            migrationBuilder.InsertData(
                table: "AccessCardPermissions",
                columns: new[] { "Id", "AccessCardId", "PermissionId" },
                values: new object[,]
                {
                    { new Guid("99999999-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("99999999-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("66666666-6666-6666-6666-666666666666") }
                });

            migrationBuilder.InsertData(
                table: "AccessCardRoles",
                columns: new[] { "Id", "AccessCardId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("99999999-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("99999999-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("88888888-8888-8888-8888-888888888888") }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-1111-1111-111111111111"), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("00000000-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("00000000-3333-3333-3333-333333333333"), new Guid("55555555-5555-5555-5555-555555555555"), new Guid("88888888-8888-8888-8888-888888888888") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessCardPermissions_AccessCardId",
                table: "AccessCardPermissions",
                column: "AccessCardId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessCardPermissions_PermissionId",
                table: "AccessCardPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessCardRoles_AccessCardId",
                table: "AccessCardRoles",
                column: "AccessCardId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessCardRoles_RoleId",
                table: "AccessCardRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLogEntries_AccessCardId",
                table: "AccessLogEntries",
                column: "AccessCardId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessCardPermissions");

            migrationBuilder.DropTable(
                name: "AccessCardRoles");

            migrationBuilder.DropTable(
                name: "AccessLogEntries");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "AccessCards");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
