using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using InventoryManagement.Domain.Entites;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Entites
{
    public class PurchaseInvoice
    {
        public int PurchaseInvoiceId { get; private set; }

        public string SupplierName { get; private set; }
        public int InvoiceNumber { get; private set; }
        public DateTime Date { get; private set; }
        public decimal TaxRate { get; private set; }

        public decimal TotalBeforeTax { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public decimal ShippingCost { get; private set; }
        public decimal TaxAmount { get; private set; }
        public decimal TotalAmount { get; private set; }


        public PaymentStatus PaymentStatus { get; private set; }

        public PaymentType PaymentType { get; private set; }
        public int UserId { get; private set; }
        private readonly List<PurchaseInvoicePayment> _payments = new();
        public IReadOnlyCollection<PurchaseInvoicePayment> Payments => _payments;

        private readonly List<PurchaseInvoiceItem> _items = new();
        public IReadOnlyCollection<PurchaseInvoiceItem> Items => _items;

        private readonly List<PurchaseInvoiceCost> _additionalCosts = new();
        public IReadOnlyCollection<PurchaseInvoiceCost> AdditionalCosts => _additionalCosts;

        private PurchaseInvoice() { }

        public static PurchaseInvoice Create(
            string supplierName,
            int invoiceNumber,
            int userId,
            PaymentType paymentType= PaymentType.Partial
            )
        {
            if (string.IsNullOrWhiteSpace(supplierName))
                throw new ArgumentException("Supplier name is required");
            return new PurchaseInvoice
            {
                SupplierName = supplierName,
                InvoiceNumber = invoiceNumber,
                UserId = userId,
                Date = DateTime.UtcNow,
                PaymentStatus = PaymentStatus.Unpaid,
                PaymentType= paymentType
            };

        }
        public void AddPayment(decimal amount, PaymentMethod method)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid amount");

            _payments.Add(new PurchaseInvoicePayment(amount, method));

            var totalPaid = _payments.Sum(p => p.Amount);

            if (totalPaid >= TotalAmount)
                PaymentStatus = PaymentStatus.Paid;
            else
                PaymentStatus = PaymentStatus.PartiallyPaid;
        }
        public void AddItem(int inventoryId, decimal quantity, decimal unitPrice)
        {
            var item = new PurchaseInvoiceItem(inventoryId, quantity, unitPrice);
            _items.Add(item);
            RecalculateTotals();
        }
        public void UpdatePaymentStatus()
        {
            var totalPaid = _payments.Sum(p => p.Amount);

            if (totalPaid == 0)
                PaymentStatus = PaymentStatus.Unpaid;
            else if (totalPaid < TotalAmount)
                PaymentStatus = PaymentStatus.PartiallyPaid;
            else
                PaymentStatus = PaymentStatus.Paid;
        }

        public void UpdatePaymentType()
        {
            if (_payments.Count == 0)
                PaymentType = PaymentType.Credit;
            else if (_payments.Sum(p => p.Amount) < TotalAmount)
                PaymentType = PaymentType.Partial;
            else
                PaymentType = PaymentType.Cash;
        }
        public void AddAdditionalCost(string Name, decimal Amount)
        {
            var cost = new PurchaseInvoiceCost(Name, Amount);
            _additionalCosts.Add(cost);
            RecalculateTotals();
        }
        public void MarkAsPaid()
        {
            PaymentStatus = PaymentStatus.Paid;
        }
        public void SetDiscount(decimal discount)
        {
            if (discount < 0)
                throw new ArgumentException("Discount cannot be negative");

            DiscountAmount = discount;
            RecalculateTotals();
        }

        public void SetShippingCost(decimal cost)
        {
            if (cost < 0)
                throw new ArgumentException("Shipping cost cannot be negative");

            ShippingCost = cost;
            RecalculateTotals();
        }
        public void SetTaxRate(decimal taxRate)
        {
            if (taxRate < 0 || taxRate > 1)
                throw new ArgumentException("Tax rate must be between 0 and 1");

            TaxRate = taxRate;
            RecalculateTotals();
        }   
        private void RecalculateTotals()
        {
            TotalBeforeTax = _items.Sum(i => i.TotalPrice)+_additionalCosts.Sum(c=>c.Amount);
            TaxAmount = TotalBeforeTax * TaxRate; // مثال
            TotalAmount = TotalBeforeTax + TaxAmount + ShippingCost - DiscountAmount;
        }



    }
}
public enum PaymentStatus
{
    Unpaid,
    PartiallyPaid,
    Paid
}
public enum PaymentType
{
    Cash,       // نقدي
    Credit,     // أجل
    Partial     // جزئي
}