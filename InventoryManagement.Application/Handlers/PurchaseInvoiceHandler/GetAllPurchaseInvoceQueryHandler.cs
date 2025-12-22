using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using InventoryManagement.Application.Queries.PusrchaseInvoiceQueries;
using InventoryManagement.Application.Service;
using MediatR;

namespace InventoryManagement.Application.Handlers.PurchaseInvoiceHandler
{
    public class GetAllPurchaseInvoceQueryHandler : IRequestHandler<GetAllPurchaseInvoceQuery, IEnumerable<PurchaseInvoice>>
    {
       private readonly IPurchaseInvoiceService _purchaseInvoiceService;
       
        public GetAllPurchaseInvoceQueryHandler(IPurchaseInvoiceService purchaseInvoiceService)
        {
            _purchaseInvoiceService = purchaseInvoiceService;
        }

        async Task<IEnumerable<PurchaseInvoice>> IRequestHandler<GetAllPurchaseInvoceQuery, IEnumerable<PurchaseInvoice>>.Handle(GetAllPurchaseInvoceQuery request, CancellationToken cancellationToken)
        {
            var result= await  _purchaseInvoiceService.GetAllInvoicesAsync();
            return result;
        }
    }
}
