using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Interface;
using InventoryManagement.Application.Queries.TransactionQueries;
using MediatR;

namespace InventoryManagement.Application.Handlers.TransactionHandler
{
    public class GetByPurchaseInvoiceQueryHandler : IRequestHandler<GetByPurchaseInvoiceQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepositoryQuery _transactionRepositoryQuery;

        public GetByPurchaseInvoiceQueryHandler(ITransactionRepositoryQuery transactionRepositoryQuery)
        {
            _transactionRepositoryQuery = transactionRepositoryQuery;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetByPurchaseInvoiceQuery request, CancellationToken cancellationToken)
        {
           var transactions = await  _transactionRepositoryQuery.GetByPurchaseInvoiceAsync(request.PurchaseInvoice);
            return transactions;
        }
    }
}
