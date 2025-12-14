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
    public class PurchaseInvoiceCostConfigration : IEntityTypeConfiguration<PurchaseInvoiceCost>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoiceCost> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Name);
            builder.Property(x=>x.Amount).HasColumnType("decimal(18,2)");
            builder.HasOne(x=>x.PurchaseInvoice).WithMany(x=>x.AdditionalCosts).HasForeignKey(x=>x.PurchaseInvoiceId);
            
        }
    }
}
