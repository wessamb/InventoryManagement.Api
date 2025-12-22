using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.Data
{
    public class PurchaseInvoicePaymentConfigration : IEntityTypeConfiguration<PurchaseInvoicePayment>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoicePayment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Amount).IsRequired().HasColumnType("decimal(18,2)");    
            builder.Property(x=> x.Date).IsRequired();  
            builder.Property(x=> x.Method).IsRequired();
            builder.ToTable("PurchaseInvoicePayments"); 
        }
    }
}
