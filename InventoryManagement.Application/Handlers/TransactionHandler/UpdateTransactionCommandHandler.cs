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
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, Transaction>
    {
        private readonly ITransactionRepository _transactionRepository;
        public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<Transaction> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            // 1️⃣ جلب الـ Transaction الحالية
            var transaction = await _transactionRepository
                .GetTransactionByIdAsync(request.transId);

            if (transaction == null)
                throw new Exception("Transaction not found");

            // 2️⃣ تحديث الحالة عبر الدومين
            transaction.UpdateTransaction(
                request.Amount,
                request.Type,
                request.PaymentMethod,
                request.Description,
                request.PurchaseInvoiceId,
                request.SalesInvoiceId
            );

            // 3️⃣ حفظ التغييرات
            await _transactionRepository.UpdateTransactionAsync(transaction);

            return transaction;
        }
    }
}
