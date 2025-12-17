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
    public class GetBySalesInvoiceQueryHandler : IRequestHandler<GetBySalesInvoiceQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepositoryQuery _transactionRepositoryQuery;
        public GetBySalesInvoiceQueryHandler(ITransactionRepositoryQuery transactionRepositoryQuery)
        {
            _transactionRepositoryQuery = transactionRepositoryQuery;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetBySalesInvoiceQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepositoryQuery.GetBySalesInvoiceAsync(request.SalesInvoice);
            return transactions;
        }
    }
}
