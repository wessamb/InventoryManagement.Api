using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.Data
{
    public class TransactionConfigration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
           builder.HasKey(t => t.TransactionId);
            builder.Property(t => t.Date)
                .IsRequired();
            builder.Property(t => t.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.Type)
                .IsRequired();
            builder.Property(x=>x.PaymentMethod) .IsRequired();
            builder.Property(x => x.Description);
       

        }
    }
}
