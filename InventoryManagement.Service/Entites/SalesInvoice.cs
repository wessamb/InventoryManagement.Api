using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Entites
{
    public class SalesInvoice
    {
        public int SalesInvoiceId { get; set; }
        public DateTime Date { get; set; }

        public int InvoiceNumber { get; set; }
       
        public decimal TotalBeforeTax { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal ShippingCost { get; set; }

        public decimal OtherCosts { get; set; }

        public string PaymentStatus { get; set; } // Paid / Unpaid / Partial
        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }


        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<SalesInvoiceItem> Items { get; set; } = new List<SalesInvoiceItem>();
    }

}
