using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Interface;
using InventoryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task DeleteTransactionAsync(int transactionId)
        {
            var transaction = await _context.Transactions
          .FirstOrDefaultAsync(x => x.TransactionId == transactionId);

            if (transaction == null)
                throw new Exception("Transaction not found");

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _context.Transactions
        .AsNoTracking()
        .ToListAsync();
        }

        public async Task<Transaction> GetTransactionByIdAsync(int transactionId)
        {
            var transaction = await  _context.Transactions.AsNoTracking().FirstOrDefaultAsync(x => x.TransactionId == transactionId);

            if (transaction == null)
                throw new Exception("Transaction not found");
            return transaction;
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
           await _context.SaveChangesAsync();
        }
    }
}
