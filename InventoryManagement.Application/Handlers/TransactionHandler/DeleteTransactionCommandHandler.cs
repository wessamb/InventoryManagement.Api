using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Command.TransactionCommand;
using InventoryManagement.Application.Interface;
using MediatR;

namespace InventoryManagement.Application.Handlers.TransactionHandler
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, string>
    {
        private readonly ITransactionRepository _transactionRepository;
        public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<string> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
           await _transactionRepository.DeleteTransactionAsync(request.TransactionId);
            return "Transaction deleted successfully.";
        }
    }
}
