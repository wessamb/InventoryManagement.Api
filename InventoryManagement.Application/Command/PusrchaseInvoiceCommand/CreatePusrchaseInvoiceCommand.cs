using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Entites;
using MediatR;

namespace InventoryManagement.Application.Command.PusrchaseInvoiceCommand
{
    public sealed record CreatePusrchaseInvoiceCommand(string supplierName,
        int invoiceNumber,
        int userId,
        List<PurchaseInvoiceItemDto> items,
        List<(string name, decimal amount)> additionalCosts,
        decimal taxRate,
        decimal shippingCost,
        PaymentType paymentTypes = PaymentType.Partial) :IRequest<PurchaseInvoice>;
}
