using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Entites;
using InventoryManagement.Application.Interface;
using InventoryManagement.Application.Service;
using InventoryManagement.Domain.Entites;

public class PurchaseInvoiceService:IPurchaseInvoiceService
{
    private readonly IPurchaseInvoiceRepository _purchaseInvoiceRepository;
    private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
    private readonly ITransactionRepository _transactionRepository;

    public PurchaseInvoiceService(
        IPurchaseInvoiceRepository purchaseInvoiceRepository,
        IInventoryTransactionRepository inventoryTransactionRepository,
        ITransactionRepository transactionRepository)
    {
        _purchaseInvoiceRepository = purchaseInvoiceRepository;
        _inventoryTransactionRepository = inventoryTransactionRepository;
        _transactionRepository = transactionRepository;
    }

    
    public async Task<PurchaseInvoice> CreateInvoiceAsync(
        string supplierName,
        int invoiceNumber,
        int userId,
        List<PurchaseInvoiceItemDto> items,
        List<(string name, decimal amount)> additionalCosts,
        decimal taxRate,
        decimal shippingCost,
        PaymentType paymentTypes = PaymentType.Partial
        )
    {
       
        var invoice = PurchaseInvoice.Create(supplierName, invoiceNumber, userId,paymentTypes);

        
        foreach (var item in items)
        {
            invoice.AddItem(item.InventoryId, item.Quantity, item.UnitPrice);

            var inventoryTransaction = InventoryTransaction.CreatePurchase(
                inventoryId: item.InventoryId,
                quantity: item.Quantity,
                purchaseInvoiceId: invoice.PurchaseInvoiceId
                
            );

            await _inventoryTransactionRepository.AddAsync(inventoryTransaction);
        }

      
        foreach (var cost in additionalCosts)
        {
            invoice.AddAdditionalCost(cost.name, cost.amount);
        }

       
        invoice.SetTaxRate(taxRate);
        invoice.SetShippingCost(shippingCost);

      
        await _purchaseInvoiceRepository.AddAsync(invoice);

        return invoice;
    }

    
    public async Task AddPaymentAsync(int invoiceId, decimal amount, PaymentMethod method, int userId)
    {
        var invoice = await _purchaseInvoiceRepository.GetByIdAsync(invoiceId);
        if (invoice == null)
            throw new ArgumentException("Invoice not found");

      
        invoice.AddPayment(amount, method);

        
        var transaction = Transaction.Create(
            amount: amount,
            type: TransactionType.Purchase,
            paymentMethod: method,
            userId: userId,
            description: $"Payment for Purchase Invoice #{invoice.InvoiceNumber}",
            purchaseInvoiceId: invoice.PurchaseInvoiceId
        );

        await _transactionRepository.AddTransactionAsync(transaction);

        
        invoice.UpdatePaymentStatus();
        invoice.UpdatePaymentType();
    }

   
    public async Task<List<PurchaseInvoice>> GetAllInvoicesAsync()
    {
        return await _purchaseInvoiceRepository.GetAllAsync();
    }
}
