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
    public class ProductionOrderItemConfigration : IEntityTypeConfiguration<ProductionOrderItem>
    {
        public void Configure(EntityTypeBuilder<ProductionOrderItem> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x=> x.Quantity)
                .IsRequired().HasColumnType("decimal(18,2)"); ;
           builder.Property(x=> x.Unit)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasOne(x => x.ProductionOrder)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.ProductionOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Inventory).WithMany(x=>x.ProductionOrderItem)
                .HasForeignKey(x => x.InventoryId)
                .OnDelete(DeleteBehavior.Restrict);





        }
    }
}
