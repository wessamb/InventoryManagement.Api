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
    public class GetByUserQueryHandler : IRequestHandler<GetByUserQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepositoryQuery _transactionRepositoryQuery;
        public GetByUserQueryHandler(ITransactionRepositoryQuery transactionRepositoryQuery) { 
        _transactionRepositoryQuery= transactionRepositoryQuery;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetByUserQuery request, CancellationToken cancellationToken)
        {
            var trans = await _transactionRepositoryQuery.GetByUserAsync(request.Userid);
            return trans;
        }
    }
}
