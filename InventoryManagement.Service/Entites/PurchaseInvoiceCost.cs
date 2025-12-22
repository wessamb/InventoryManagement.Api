using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Entites
{
    public class PurchaseInvoiceCost
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Amount { get; private set; }
        internal PurchaseInvoiceCost(string name, decimal amount) { if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Cost name is required");
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero");
            Name = name; Amount = amount; }

    }

}
