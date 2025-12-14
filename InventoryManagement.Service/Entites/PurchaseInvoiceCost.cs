using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Entites
{
    public class PurchaseInvoiceCost
    {
        public int Id { get; set; }
        public int PurchaseInvoiceId { get; set; }
        public PurchaseInvoice PurchaseInvoice { get; set; }

        public string Name { get; set; }   // اسم المصروف، مثال: "تخليص جمركي"
        public decimal Amount { get; set; } // قيمة المصروف
    }
}
