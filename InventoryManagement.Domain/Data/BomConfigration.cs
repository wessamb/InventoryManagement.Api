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
    public class BomConfigration : IEntityTypeConfiguration<BOM>
    {
        public void Configure(EntityTypeBuilder<BOM> builder)
        {
            builder.HasKey(x => x.BOMId);
            builder.Property(x => x.QuantityNeeded).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Product)
          .WithMany(x => x.BOMs)
          .HasForeignKey(x => x.ProductId)
          .OnDelete(DeleteBehavior.NoAction);  // يمنع multiple cascade paths

            builder.HasOne(x => x.Inventory)
                   .WithMany(x => x.BOMs)
                   .HasForeignKey(x => x.InventoryId)
                   .OnDelete(DeleteBehavior.NoAction);  // يمنع multiple cascade paths

        }
    }
}
