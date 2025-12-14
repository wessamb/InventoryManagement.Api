using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Entites
{
    public class ProductionOrderItemCost
    {
      public int  ProductionOrderCostId { get; set; }

       

        public int ProductionOrderItemId { get; set; }
        public ProductionOrderItem ProductionOrderItem { get; set; }
        public string Name { get; set; } // اسم التكلفة

        public decimal Cost { get; set; } // مبلغ التكلفة

    }
}
