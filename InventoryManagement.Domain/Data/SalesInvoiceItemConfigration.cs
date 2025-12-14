using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.Data
{
    public class SalesInvoiceItemConfigration : IEntityTypeConfiguration<SalesInvoiceItem>
    {
        public void Configure(EntityTypeBuilder<SalesInvoiceItem> builder)
        {
            builder.HasKey(sii => sii.SalesInvoiceItemId);
            builder.Property(sii => sii.Quantity).IsRequired();
            builder.Property(sii => sii.UnitPrice).IsRequired();
           builder.Property(sii => sii.Discount).IsRequired();
            builder.Property(sii => sii.TotalPrice).IsRequired();
            builder.Property(sii => sii.CostPerUnit).IsRequired();
            builder.Property(sii => sii.TotalCost).IsRequired();
            builder.HasOne(sii => sii.Product)
                   .WithMany(p => p.SalesItems)
                   .HasForeignKey(sii => sii.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(sii => sii.SalesInvoice)
                   .WithMany(si => si.Items)
                   .HasForeignKey(sii => sii.SalesInvoiceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
