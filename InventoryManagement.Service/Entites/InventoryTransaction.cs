using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entites
{
    public class InventoryTransaction
    {
        public int Id { get; private set; }

        public int InventoryId { get; private set; }
        public Inventory Inventory { get; private set; }

        public decimal Quantity { get; private set; }
        public InventoryTransactionType Type { get; private set; }

        public DateTime Date { get; private set; }

        public int? PurchaseInvoiceId { get; private set; }
        public int? SalesInvoiceId { get; private set; }

     
        private InventoryTransaction() { }

  
        public static InventoryTransaction CreatePurchase(
            int inventoryId,
            decimal quantity,
            int purchaseInvoiceId
        )
        {
            if (quantity <= 0)
                throw new ArgumentException("Purchase quantity must be positive");

            return new InventoryTransaction
            {
                InventoryId = inventoryId,
                Quantity = quantity, 
                Type = InventoryTransactionType.Purchase,
                PurchaseInvoiceId = purchaseInvoiceId,
                Date = DateTime.UtcNow
            };
        }

        public static InventoryTransaction CreateSale(
            int inventoryId,
            decimal quantity,
            int salesInvoiceId
        )
        {
            if (quantity <= 0)
                throw new ArgumentException("Sale quantity must be positive");

            return new InventoryTransaction
            {
                InventoryId = inventoryId,
                Quantity = -quantity, 
                Type = InventoryTransactionType.Sale,
                SalesInvoiceId = salesInvoiceId,
                Date = DateTime.UtcNow
            };
        }
    }


    public enum InventoryTransactionType
    {
        Purchase,        // شراء → دخول مخزون
        Sale,            // بيع → خروج مخزون
        ProductionIn,    // ناتج إنتاج → دخول
        ProductionOut,   // مواد خام للإنتاج → خروج
        Adjustment,      // جرد / تعديل يدوي
        Damage            // تلف
    }


}
