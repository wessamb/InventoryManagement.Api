using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Entites
{
    public class PurchaseInvoice
    {
        public int PurchaseInvoiceId { get; set; }
        public string SupplierName { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalBeforeTax { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal ShippingCost { get; set; }

        

        public string PaymentStatus { get; set; } // Paid / Unpaid / Partial
        public decimal TaxAmount { get; set; }
        
        public decimal TotalAmount { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<PurchaseInvoiceItem> Items { get; set; }= new List<PurchaseInvoiceItem>();
        public ICollection<PurchaseInvoiceCost> AdditionalCosts { get; set; } = new List<PurchaseInvoiceCost>();

    }
}
