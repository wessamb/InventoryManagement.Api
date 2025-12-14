using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.Data
{
    public class InventoryConfigration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(x => x.InventoryID);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Unit).IsRequired().HasMaxLength(20);
            builder.Property(x => x.AverageCost).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.QuantityOnHand).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
