using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Entites
{
    public class InventoryRecord
    {
        public int InventoryRecordId { get; set; } // PK
        public int ProductId { get; set; }         // FK
        public Product Product { get; set; }

        public int WarehouseId { get; set; }       // FK
        public Warehouse Warehouse { get; set; }

        public decimal Quantity { get; set; }
        public decimal CostPerUnit { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
