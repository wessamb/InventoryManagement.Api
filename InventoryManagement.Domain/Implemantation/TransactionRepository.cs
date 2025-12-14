using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Interface;
using InventoryManagement.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Infrastructure.Implemantation
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TransactionRepository> _logger;
        public TransactionRepository(AppDbContext context, ILogger<TransactionRepository> logger) {
        _context = context;
        _logger = logger;

        }
        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            var tra=  Transaction.Create(transaction.Amount, transaction.Type, transaction.PaymentMethod, transaction.UserId, transaction.Description, transaction.PurchaseInvoiceId, transaction.SalesInvoiceId);
            await _context.Transactions.AddAsync(tra);
            await _context.SaveChangesAsync();
            return tra;
        }

        public Task DeleteTransactionAsync(int transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetByPurchaseInvoiceAsync(int purchaseInvoiceId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetBySalesInvoiceAsync(int salesInvoiceId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalAmountByTypeAsync(TransactionType type)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetTransactionByIdAsync(int transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetTransactionsByTypeAsync(TransactionType type)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTransactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
