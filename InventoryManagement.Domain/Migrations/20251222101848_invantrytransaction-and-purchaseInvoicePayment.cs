using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class invantrytransactionandpurchaseInvoicePayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceItems_Inventory_InventoryID",
                table: "PurchaseInvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoices_Users_UserId",
                table: "PurchaseInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PurchaseInvoices_PurchaseInvoiceId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PurchaseInvoiceId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoices_UserId",
                table: "PurchaseInvoices");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceItems_InventoryID",
                table: "PurchaseInvoiceItems");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "PurchaseInvoiceItems");

            migrationBuilder.RenameColumn(
                name: "InventoryID",
                table: "PurchaseInvoiceItems",
                newName: "InventoryId");

            migrationBuilder.RenameColumn(
                name: "PurchaseInvoiceItemId",
                table: "PurchaseInvoiceItems",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "PurchaseInvoices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "PurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate",
                table: "PurchaseInvoices",
                type: "decimal(5,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "PurchaseInvoiceItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "PurchaseInvoiceItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseInvoiceId",
                table: "PurchaseInvoiceItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseInvoiceId",
                table: "PurchaseInvoiceCost",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "InventoryTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: true),
                    SalesInvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoicePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoicePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoicePayments_PurchaseInvoices_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalTable: "PurchaseInvoices",
                        principalColumn: "PurchaseInvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_InventoryId",
                table: "InventoryTransactions",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoicePayments_PurchaseInvoiceId",
                table: "PurchaseInvoicePayments",
                column: "PurchaseInvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryTransactions");

            migrationBuilder.DropTable(
                name: "PurchaseInvoicePayments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                table: "PurchaseInvoices");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "PurchaseInvoiceItems",
                newName: "InventoryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PurchaseInvoiceItems",
                newName: "PurchaseInvoiceItemId");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "PurchaseInvoices",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                table: "PurchaseInvoiceItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "PurchaseInvoiceItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseInvoiceId",
                table: "PurchaseInvoiceItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "PurchaseInvoiceItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseInvoiceId",
                table: "PurchaseInvoiceCost",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PurchaseInvoiceId",
                table: "Transactions",
                column: "PurchaseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_UserId",
                table: "PurchaseInvoices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceItems_InventoryID",
                table: "PurchaseInvoiceItems",
                column: "InventoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceItems_Inventory_InventoryID",
                table: "PurchaseInvoiceItems",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoices_Users_UserId",
                table: "PurchaseInvoices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PurchaseInvoices_PurchaseInvoiceId",
                table: "Transactions",
                column: "PurchaseInvoiceId",
                principalTable: "PurchaseInvoices",
                principalColumn: "PurchaseInvoiceId");
        }
    }
}
