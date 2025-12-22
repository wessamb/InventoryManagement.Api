using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using MediatR;

namespace InventoryManagement.Application.Queries.PusrchaseInvoiceQueries
{
    public sealed record  GetAllPurchaseInvoceQuery():IRequest<IEnumerable<PurchaseInvoice>>;
}
