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
    public class GetTotalAmountByTypeQueryHandler : IRequestHandler<GetTotalAmountByTypeQuery, decimal>
    {
        private readonly ITransactionRepositoryQuery _transactionRepositoryQuery;
        public GetTotalAmountByTypeQueryHandler(ITransactionRepositoryQuery transactionRepositoryQuery)
        {
            _transactionRepositoryQuery = transactionRepositoryQuery;
        }

        public async Task<decimal> Handle(GetTotalAmountByTypeQuery request, CancellationToken cancellationToken)
        {
         var transactions = await _transactionRepositoryQuery.GetTotalAmountByTypeAsync(request.type);
            return transactions;
        }
    }
}
