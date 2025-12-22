using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.Entites;

namespace InventoryManagement.Application.Interface
{
    public interface IInventoryTransactionRepository
    {
        Task AddAsync(InventoryTransaction inventoryTransaction);
        Task<List<InventoryTransaction>> GetByInventoryIdAsync(int inventoryId);
    }
}
