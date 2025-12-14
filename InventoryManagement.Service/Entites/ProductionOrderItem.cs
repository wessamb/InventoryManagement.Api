using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Entites
{
    public class ProductionOrderItem
    {
        public int Id { get; set; }

        // الربط مع أمر الإنتاج
        public int ProductionOrderId { get; set; }
        public ProductionOrder ProductionOrder { get; set; }

       
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        // الكمية المطلوبة
        public decimal Quantity { get; set; }

        // الوحدة (اختياري)
        public string Unit { get; set; } // مثل: kg, piece, liter

        // ربط التكلفة
        public ICollection<ProductionOrderItemCost> Costs { get; set; }
    }
}
