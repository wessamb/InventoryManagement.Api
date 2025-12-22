using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Entites;

namespace InventoryManagement.Application.Service
{
    public interface IPurchaseInvoiceService
    {
         Task<PurchaseInvoice> CreateInvoiceAsync(
            string supplierName,
            int invoiceNumber,
            int userId,
            List<PurchaseInvoiceItemDto> items,
            List<(string name, decimal amount)> additionalCosts,
            decimal taxRate,
            decimal shippingCost,
            PaymentType paymentTypes = PaymentType.Partial
            );
        Task AddPaymentAsync(int invoiceId, decimal amount, PaymentMethod method, int userId);

        Task<List<PurchaseInvoice>> GetAllInvoicesAsync();


    }
}
