using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Entites
{
    public class Warehouse
    {
        public int WarehouseId { get; set; } // PK
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<InventoryRecord> InventoryRecords { get; set; } = new List<InventoryRecord>();
    }
}
