using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ddddesign1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_Users_CreatedBy",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoices_Users_UserId",
                table: "PurchaseInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PurchaseInvoices_PurchaseInvoiceId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_SalesInvoices_SalesInvoiceId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_ProductionOrders_CreatedBy",
                table: "ProductionOrders");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(600)",
                oldMaxLength: 600);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProductionOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_UserId",
                table: "ProductionOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_Users_UserId",
                table: "ProductionOrders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_SalesInvoices_SalesInvoiceId",
                table: "Transactions",
                column: "SalesInvoiceId",
                principalTable: "SalesInvoices",
                principalColumn: "SalesInvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_Users_UserId",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoices_Users_UserId",
                table: "PurchaseInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PurchaseInvoices_PurchaseInvoiceId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_SalesInvoices_SalesInvoiceId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_ProductionOrders_UserId",
                table: "ProductionOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductionOrders");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_CreatedBy",
                table: "ProductionOrders",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_Users_CreatedBy",
                table: "ProductionOrders",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoices_Users_UserId",
                table: "PurchaseInvoices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PurchaseInvoices_PurchaseInvoiceId",
                table: "Transactions",
                column: "PurchaseInvoiceId",
                principalTable: "PurchaseInvoices",
                principalColumn: "PurchaseInvoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_SalesInvoices_SalesInvoiceId",
                table: "Transactions",
                column: "SalesInvoiceId",
                principalTable: "SalesInvoices",
                principalColumn: "SalesInvoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
