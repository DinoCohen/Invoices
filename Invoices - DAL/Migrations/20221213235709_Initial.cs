using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoices___DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceNumber = table.Column<int>(nullable: false),
                    InvoiceCreation = table.Column<DateTime>(nullable: false),
                    InvoiceLastChange = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
