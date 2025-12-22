using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Command.PusrchaseInvoiceCommand;
using InventoryManagement.Application.Entites;
using InventoryManagement.Application.Interface;
using InventoryManagement.Application.Service;
using MediatR;

namespace InventoryManagement.Application.Handlers.PurchaseInvoiceHandler
{
    public class CreatePusrchaseInvoiceCommandHandler : IRequestHandler<CreatePusrchaseInvoiceCommand, PurchaseInvoice>
    {
        private readonly IPurchaseInvoiceService _purchaseInvoiceService;

        public CreatePusrchaseInvoiceCommandHandler(IPurchaseInvoiceService purchaseInvoiceService)
        {
            _purchaseInvoiceService = purchaseInvoiceService;
        }

        public async Task<PurchaseInvoice> Handle(CreatePusrchaseInvoiceCommand request, CancellationToken cancellationToken)
        {
          var result=   await _purchaseInvoiceService.CreateInvoiceAsync (request.supplierName, request.invoiceNumber, request.userId,request.items,request.additionalCosts,request.taxRate,request.shippingCost ,request.paymentTypes);
            return result;
        }
    }
}
