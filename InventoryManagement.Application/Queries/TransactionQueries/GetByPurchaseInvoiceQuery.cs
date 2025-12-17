using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InventoryManagement.Application.Queries.TransactionQueries
{
    public sealed record GetByPurchaseInvoiceQuery(int PurchaseInvoice) :IRequest<IEnumerable<Transaction>>;
    
}
