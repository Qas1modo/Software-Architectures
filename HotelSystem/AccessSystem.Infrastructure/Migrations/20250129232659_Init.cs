using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermissionCodeName = table.Column<string>(type: "TEXT", nullable: false),
                    PermissionName = table.Column<string>(type: "TEXT", nullable: false),
                    PermissionDescription = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "AccessCardPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccessCardId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCardPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessCardPermissions_AccessCards_AccessCardId",
                        column: x => x.AccessCardId,
                        principalTable: "AccessCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessCardPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessClaimPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccessClaimId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessClaimPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessClaimPermissions_AccessClaims_AccessClaimId",
                        column: x => x.AccessClaimId,
                        principalTable: "AccessClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessClaimPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
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
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
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
                columns: new[] { "Id", "DeletedOnUtc", "HolderId", "ModifiedOnUtc" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, new Guid("00000000-0000-0000-0000-000000000001"), null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("00000000-0000-0000-0000-000000000002"), null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, new Guid("00000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "DeletedOnUtc", "ModifiedOnUtc", "PermissionCodeName", "PermissionDescription", "PermissionName" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, null, "Gym", "Gym permission", "Gym" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, null, "Pool", "Pool permission", "Pool" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), null, null, "Maintenance", "Maintenance permission", "Maintenance" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeletedOnUtc", "ModifiedOnUtc", "RoleCodeName", "RoleDescription", "RoleName" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), null, null, "Receptionist", "Receptionist role", "Receptionist" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), null, null, "Guest", "Guest role", "Guest" }
                });

            migrationBuilder.InsertData(
                table: "AccessCardPermissions",
                columns: new[] { "Id", "AccessCardId", "DeletedOnUtc", "ModifiedOnUtc", "PermissionId" },
                values: new object[,]
                {
                    { new Guid("99999999-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), null, null, new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("99999999-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333"), null, null, new Guid("66666666-6666-6666-6666-666666666666") }
                });

            migrationBuilder.InsertData(
                table: "AccessCardRoles",
                columns: new[] { "Id", "AccessCardId", "DeletedOnUtc", "ModifiedOnUtc", "RoleId" },
                values: new object[,]
                {
                    { new Guid("99999999-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), null, null, new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("99999999-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222"), null, null, new Guid("88888888-8888-8888-8888-888888888888") }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "DeletedOnUtc", "ModifiedOnUtc", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-1111-1111-111111111111"), null, null, new Guid("44444444-4444-4444-4444-444444444444"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("00000000-2222-2222-2222-222222222222"), null, null, new Guid("44444444-4444-4444-4444-444444444444"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("00000000-3333-3333-3333-333333333333"), null, null, new Guid("55555555-5555-5555-5555-555555555555"), new Guid("88888888-8888-8888-8888-888888888888") }
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
                name: "IX_AccessClaimPermissions_AccessClaimId",
                table: "AccessClaimPermissions",
                column: "AccessClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessClaimPermissions_PermissionId",
                table: "AccessClaimPermissions",
                column: "PermissionId");

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
                name: "AccessClaimPermissions");

            migrationBuilder.DropTable(
                name: "AccessLogEntries");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "AccessClaims");

            migrationBuilder.DropTable(
                name: "AccessCards");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
