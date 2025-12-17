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
    public class GetTransactionsByDateRangeQueryHandler : IRequestHandler<GetTransactionsByDateRangeQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepositoryQuery _transactionRepositoryQuery;
        public GetTransactionsByDateRangeQueryHandler(ITransactionRepositoryQuery transactionRepositoryQuery) { 
        _transactionRepositoryQuery= transactionRepositoryQuery;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetTransactionsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepositoryQuery.GetTransactionsByDateRangeAsync(request.startDate, request.endDate);
            return transaction;
        }
    }
}
