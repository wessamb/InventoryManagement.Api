using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Data
{
    public class InventoryTransactionConfigration: IEntityTypeConfiguration<InventoryManagement.Domain.Entites.InventoryTransaction>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InventoryManagement.Domain.Entites.InventoryTransaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.HasOne(x => x.Inventory)
       .WithMany(x=> x.inventoryTransactions)
       .HasForeignKey(x => x.InventoryId)
       .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.PurchaseInvoiceId);
            builder.Property(x => x.SalesInvoiceId);

            builder.ToTable("InventoryTransactions");
        }
    
    }
}
