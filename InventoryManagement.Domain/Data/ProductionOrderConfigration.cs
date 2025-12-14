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
    public class ProductionOrderConfigration : IEntityTypeConfiguration<ProductionOrder>
    {
        public void Configure(EntityTypeBuilder<ProductionOrder> builder)
        {
            builder.HasKey(x => x.ProductionOrderId);
            builder.Property(x=> x.Status).IsRequired().HasMaxLength(50);
            builder.Property(x=> x.ProductionCost).HasColumnType("decimal(18,2)");
            builder.Property(x=> x.WasteQuantity).HasColumnType("decimal(18,2)");
            builder.Property(x=> x.QuantityToProduce).IsRequired();
         
            builder.HasOne(x=>x.Product).WithMany(x=>x.ProductionOrders).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
