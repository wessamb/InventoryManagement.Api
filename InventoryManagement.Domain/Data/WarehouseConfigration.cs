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
    public class WarehouseConfigration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(w => w.WarehouseId);
            builder.Property(w => w.Name).IsRequired().HasMaxLength(100);
            builder.Property(w => w.Location).HasMaxLength(200);

            builder.HasMany(w => w.InventoryRecords)
                   .WithOne(r => r.Warehouse)
                   .HasForeignKey(r => r.WarehouseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
