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
    public class PurchaseInvoiceConfigration : IEntityTypeConfiguration<PurchaseInvoice>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoice> builder)
        {
            builder.HasKey(x => x.PurchaseInvoiceId);
            builder.Property(x=>x.SupplierName).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.InvoiceNumber).IsRequired().HasMaxLength(12);
            builder.Property(x => x.PaymentStatus)
        .HasConversion<string>()
        .IsRequired();
            builder.Property(x => x.TotalAmount).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalBeforeTax).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TaxAmount).HasColumnType("decimal(18,2)");
            builder.Property(x => x.DiscountAmount).HasColumnType("decimal(18,2)");
            builder.Property(x => x.ShippingCost).HasColumnType("decimal(18,2)");
            builder.HasMany(x => x.Items)
       .WithOne()
       .HasForeignKey("PurchaseInvoiceId")
       .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.Date).IsRequired();

            builder.Property(x => x.TaxRate)
                   .HasColumnType("decimal(5,4)");

            builder.HasMany(x => x.AdditionalCosts)
                   .WithOne()
                   .HasForeignKey("PurchaseInvoiceId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Payments)
                   .WithOne()
                   .HasForeignKey("PurchaseInvoiceId")
                   .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
