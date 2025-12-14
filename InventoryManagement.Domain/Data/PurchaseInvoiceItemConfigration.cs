using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.Data
{
    public class PurchaseInvoiceItemConfigration : IEntityTypeConfiguration<PurchaseInvoiceItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoiceItem> builder)
        {
            builder.HasKey(x=>x.PurchaseInvoiceItemId);
            builder.Property(x=>x.Quantity).IsRequired();
            builder.Property(x=>x.TotalPrice).IsRequired();
            builder.Property(x=>x.UnitPrice).IsRequired();
            builder.HasOne(x=>x.Inventory).WithMany(x=>x.PurchaseItems).HasForeignKey(x=>x.InventoryID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.PurchaseInvoice).WithMany(x=>x.Items).HasForeignKey(x=>x.PurchaseInvoiceId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
