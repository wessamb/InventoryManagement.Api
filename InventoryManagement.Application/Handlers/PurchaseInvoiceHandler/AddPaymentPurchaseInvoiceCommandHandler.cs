using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Command.PusrchaseInvoiceCommand;
using InventoryManagement.Application.Entites;
using InventoryManagement.Application.Service;
using MediatR;

namespace InventoryManagement.Application.Handlers.PurchaseInvoiceHandler
{
    public class AddPaymentPurchaseInvoiceCommandHandler : IRequestHandler<AddPaymentPurchaseInvoiceCommand, string>
    {
        private readonly IPurchaseInvoiceService _purchaseInvoiceService;
        public AddPaymentPurchaseInvoiceCommandHandler(IPurchaseInvoiceService purchaseInvoiceService)
        {
            _purchaseInvoiceService = purchaseInvoiceService;
        }
        public async Task<string> Handle(AddPaymentPurchaseInvoiceCommand request, CancellationToken cancellationToken)
        {
             await _purchaseInvoiceService.AddPaymentAsync(request.invoiceId, request.amount, request.method, request.userId);
            return "Payment added successfully";    
        }
    }
}
