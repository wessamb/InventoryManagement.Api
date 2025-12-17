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
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepository _transactionRepository;
        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
           var transactions = await  _transactionRepository.GetAllTransactionsAsync();
            return transactions;
        }
    }
}
