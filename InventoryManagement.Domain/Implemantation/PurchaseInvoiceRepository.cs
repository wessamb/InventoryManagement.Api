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
    public class PurchaseInvoiceRepository:IPurchaseInvoiceRepository
    {
        private readonly AppDbContext _context;

        public PurchaseInvoiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(PurchaseInvoice purchaseInvoice)
        {
            _context.PurchaseInvoices.Add(purchaseInvoice);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PurchaseInvoice>> GetAllAsync()
        {
            var ListPurchase= await _context.PurchaseInvoices.ToListAsync();
            return ListPurchase;
        }

        public async Task<PurchaseInvoice> GetByIdAsync(int id)
        {
           var purchaseInvoice= await _context.PurchaseInvoices
                .Where(pi => pi.PurchaseInvoiceId == id)
                .FirstOrDefaultAsync();
            return purchaseInvoice;
        }
    }
}
