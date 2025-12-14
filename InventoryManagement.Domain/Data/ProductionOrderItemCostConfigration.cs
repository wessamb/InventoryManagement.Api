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
    public class ProductionOrderItemCostConfigration : IEntityTypeConfiguration<ProductionOrderItemCost>
    {
        public void Configure(EntityTypeBuilder<ProductionOrderItemCost> builder)
        {
           builder.HasKey(x=>x.ProductionOrderCostId);
            builder.Property(x=>x.Name).HasColumnName("Name").HasMaxLength(200);
            builder.Property(x=>x.Cost).HasColumnType("decimal(18,2)");
            builder.HasOne(x=>x.ProductionOrderItem).WithMany(x=>x.Costs).HasForeignKey(x=>x.ProductionOrderItemId);



        }
    }
}
