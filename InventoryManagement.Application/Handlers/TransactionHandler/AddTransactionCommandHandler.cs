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
    public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, Transaction>
    {
        private readonly ITransactionRepository _transactionRepository;
        public AddTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<Transaction> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = Transaction.Create(
                request.Amount,
                request.Type,
                request.PaymentMethod,
                request.UserId,
                request.Description,
                request.PurchaseInvoiceId,
                request.SalesInvoiceId
            );
       var tran= await     _transactionRepository.AddTransactionAsync(transaction);
            return tran;
        }
    }
}
