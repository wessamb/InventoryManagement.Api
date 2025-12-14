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
    public class SalesInvoiceConfigration : IEntityTypeConfiguration<SalesInvoice>
    {
        public void Configure(EntityTypeBuilder<SalesInvoice> builder)
        {
           builder.HasKey(si => si.SalesInvoiceId);
              builder.Property(si => si.Date).IsRequired();
              builder.Property(si => si.InvoiceNumber).IsRequired();
                builder.Property(si => si.TotalBeforeTax).HasColumnType("decimal(18,2)").IsRequired();
                builder.Property(si => si.DiscountAmount).HasColumnType("decimal(18,2)").IsRequired();
                builder.Property(si => si.ShippingCost).HasColumnType("decimal(18,2)").IsRequired();
                builder.Property(si => si.OtherCosts).HasColumnType("decimal(18,2)").IsRequired();
                builder.Property(si => si.PaymentStatus).IsRequired().HasMaxLength(50);
                builder.Property(si => si.TaxAmount).HasColumnType("decimal(18,2)").IsRequired();
                builder.Property(si => si.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();

        }
    }
}
