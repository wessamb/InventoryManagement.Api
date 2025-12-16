using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using InventoryManagement.Application.Interface;
using InventoryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Implemantation
{
    public class TransactionRepositoryQuery : ITransactionRepositoryQuery
    {
        private readonly AppDbContext _context;

        public TransactionRepositoryQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetByPurchaseInvoiceAsync(int purchaseInvoiceId)
        {
           var transaction= await _context.Transactions.Where(x=>x.PurchaseInvoiceId==purchaseInvoiceId).ToListAsync();
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetBySalesInvoiceAsync(int salesInvoiceId)
        {
            var transaction = await _context.Transactions.Where(x => x.SalesInvoiceId == salesInvoiceId).ToListAsync();
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetByUserAsync(int userId)
        {
            var transaction = await _context.Transactions.Where(x => x.UserId == userId).ToListAsync();
            return transaction;
        }

        public async Task<decimal> GetTotalAmountByTypeAsync(TransactionType type)
        {
            var transaction =await _context.Transactions.AsNoTracking().Where(t=>t.Type==type).SumAsync(x=>x.Amount);
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
           var transactions= await _context.Transactions.Where(t=>t.Date>=startDate && t.Date<=endDate).ToListAsync();
            return transactions;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByTypeAsync(TransactionType type)
        {
           var transaction= await _context.Transactions.Where(t=>t.Type==type).ToListAsync();
            return transaction;
        }
    }
}
