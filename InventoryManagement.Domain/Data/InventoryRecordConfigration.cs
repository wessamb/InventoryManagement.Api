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
    public class InventoryRecordConfigration : IEntityTypeConfiguration<InventoryRecord>
    {
        public void Configure(EntityTypeBuilder<InventoryRecord> builder)
        {
            builder.HasKey(r => r.InventoryRecordId);

            builder.Property(r => r.Quantity).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(r => r.CostPerUnit).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(r => r.BatchNumber).HasMaxLength(50);
            builder.Property(r => r.ExpiryDate).IsRequired();
            builder.Property(r => r.ReceivedDate).IsRequired();

            builder.HasOne(r => r.Product)
                   .WithMany(p => p.InventoryRecords)
                   .HasForeignKey(r => r.ProductId);

            builder.HasOne(r => r.Warehouse)
                   .WithMany(w => w.InventoryRecords)
                   .HasForeignKey(r => r.WarehouseId);
        }
    }
}
