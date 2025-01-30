using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSystem.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingItems",
                columns: table => new
                {
                    BillingItemId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    table.PrimaryKey("PK_BillingItems", x => x.BillingItemId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingItems");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
