using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingItemEntitys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId_Value = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId_Value = table.Column<Guid>(type: "TEXT", nullable: false),
                    UnitPrice_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity_Value = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoiceId_Value = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingItemEntitys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceEntitys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId_Value = table.Column<Guid>(type: "TEXT", nullable: false),
                    FinalPrice_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    CurrencyCode_Value = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentId_Value = table.Column<string>(type: "TEXT", nullable: false),
                    IsPaid_Value = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceEntitys", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingItemEntitys");

            migrationBuilder.DropTable(
                name: "InvoiceEntitys");
        }
    }
}
