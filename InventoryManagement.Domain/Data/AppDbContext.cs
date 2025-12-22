using System;
using InventoryManagement.Application.Entites; // استخدم هذا فقط
using InventoryManagement.Domain.Entites;
using InventoryManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BOM> BOMs { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<ProductionOrderItem> ProductionOrderItems { get; set; }
        public DbSet<ProductionOrderItemCost> ProductionOrderItemCosts { get; set; }
        public DbSet<InventoryRecord> InventoryRecords { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }

        public DbSet<PurchaseInvoicePayment> purchaseInvoicePayments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.Entity<Role>().HasData(
     new Role { RoleId = 1, RoleName = "Admin" },
     new Role { RoleId = 2, RoleName = "Sales" },
     new Role { RoleId = 3, RoleName = "Inventory" },
     new Role { RoleId = 4, RoleName = "Accountant" }
 );
        }
    }
}
