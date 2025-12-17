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
    public class GetTransactionsByTypeQueryHandler : IRequestHandler<GetTransactionsByTypeQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepositoryQuery _transactionRepositoryQuery;
        public GetTransactionsByTypeQueryHandler(ITransactionRepositoryQuery transactionRepositoryQuery) { 
        _transactionRepositoryQuery= transactionRepositoryQuery;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetTransactionsByTypeQuery request, CancellationToken cancellationToken)
        {
            var trans = await _transactionRepositoryQuery.GetTransactionsByTypeAsync(request.type);
            return trans;
        }
    }
}
