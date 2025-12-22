using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.Data
{
    public class PurchaseInvoiceItemConfigration : IEntityTypeConfiguration<PurchaseInvoiceItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoiceItem> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Quantity).IsRequired();
            builder
    .Ignore(p => p.TotalPrice);
            builder.Property(x=>x.UnitPrice).IsRequired();
       
        }
    }
}
