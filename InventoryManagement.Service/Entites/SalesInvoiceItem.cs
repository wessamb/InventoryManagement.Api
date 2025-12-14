using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryManagement.Application.Entites
{
    public class SalesInvoiceItem
    {
        public int SalesInvoiceItemId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public double Quantity { get; set; }
        public double UnitPrice { get; set; }

        public double Discount { get; set; }

        public double TotalPrice { get; set; }

        public double CostPerUnit { get; set; }

        public double TotalCost { get; set; }  
        public int SalesInvoiceId { get; set; }
        public SalesInvoice SalesInvoice { get; set; }
    }

}
