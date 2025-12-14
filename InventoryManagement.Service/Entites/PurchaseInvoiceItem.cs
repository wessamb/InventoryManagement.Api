using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Entites
{
    public class PurchaseInvoiceItem
    {
        public int PurchaseInvoiceItemId { get; set; }
        
       
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        // Relations
        public int PurchaseInvoiceId { get; set; }
        public PurchaseInvoice PurchaseInvoice { get; set; }
        public int InventoryID { get; set; }
        public Inventory Inventory { get; set; }
    }
}
