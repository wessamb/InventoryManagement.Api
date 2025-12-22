using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Interface;
using InventoryManagement.Domain.Entites;
using InventoryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Implemantation
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly AppDbContext _context;
        public InventoryTransactionRepository(AppDbContext context) {
        _context = context;
        }
        public async Task AddAsync(InventoryTransaction inventoryTransaction)
        {
            _context.InventoryTransactions.Add(inventoryTransaction);
            await _context.SaveChangesAsync();
        }

        public async Task<List<InventoryTransaction>> GetByInventoryIdAsync(int inventoryId)
        {
            var TransInvastor = await _context.InventoryTransactions.AsNoTracking().Where(x => x.InventoryId == inventoryId).ToListAsync();
            return TransInvastor;
        }
    }
}
