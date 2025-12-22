using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;

namespace InventoryManagement.Application.Interface
{
    public interface IPurchaseInvoiceRepository
    {
        Task AddAsync(PurchaseInvoice purchaseInvoice);
        Task<PurchaseInvoice> GetByIdAsync(int id);

        Task<List<PurchaseInvoice>> GetAllAsync();




    }
}
