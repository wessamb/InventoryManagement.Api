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
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, Transaction>
    {
        private readonly ITransactionRepository _transactionRepository;
        public GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<Transaction> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var trans=await _transactionRepository.GetTransactionByIdAsync(request.transId);
            return trans;
        }
    }
}
