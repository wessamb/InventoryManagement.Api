using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryManagement.Application.Entites
{
    public class BOM
    {
        public int BOMId { get; set; }               // معرف السطر في BOM
        public int ProductId { get; set; }           // FK → المنتج النهائي
        public Product Product { get; set; }         // علاقة مع المنتج النهائي

        public int InventoryId { get; set; }         // FK → المادة الخام
        public Inventory Inventory { get; set; }     // علاقة مع المخزون (Raw Material)

        public double QuantityNeeded { get; set; }   // كمية المادة لكل وحدة منتج
    }
}
