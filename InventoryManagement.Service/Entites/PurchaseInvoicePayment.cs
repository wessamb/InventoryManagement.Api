using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entites
{
    public class PurchaseInvoicePayment
    {
        public int Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public PaymentMethod Method { get; private set; }

        internal PurchaseInvoicePayment(decimal amount, PaymentMethod method)
        {
            Amount = amount;
            Method = method;
            Date = DateTime.UtcNow;
        }
    }
}
