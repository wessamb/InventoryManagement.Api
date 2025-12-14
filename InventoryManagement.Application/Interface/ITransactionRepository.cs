using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Interface
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int transactionId);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();

        Task UpdateTransactionAsync(Transaction transaction);

        Task DeleteTransactionAsync(int transactionId);

        Task<IEnumerable<Transaction>> GetTransactionsByTypeAsync(TransactionType type);

        Task<IEnumerable<Transaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate);

        Task<decimal> GetTotalAmountByTypeAsync(TransactionType type);

        Task<IEnumerable<Transaction>> GetByUserAsync(int userId);

        Task<IEnumerable<Transaction>> GetByPurchaseInvoiceAsync(int purchaseInvoiceId);
        Task<IEnumerable<Transaction>> GetBySalesInvoiceAsync(int salesInvoiceId);
    }
}
