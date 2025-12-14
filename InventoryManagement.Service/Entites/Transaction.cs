using InventoryManagement.Application.Entites;

public class Transaction
{
    public int TransactionId { get; set; }
    public DateTime Date { get; set; }

    // المبلغ
    public decimal Amount { get; set; }

    // نوع الحركة المالية
    public TransactionType Type { get; set; } // Enum: Purchase, Sale, Expense, Production, Adjustment

    // طريقة الدفع
    public PaymentMethod PaymentMethod { get; set; } // Enum: Cash, Bank, Credit

    // وصف اختياري
    public string Description { get; set; }

    // الربط مع فواتير الشراء والبيع
    public int? PurchaseInvoiceId { get; set; }


    public int? SalesInvoiceId { get; set; }

    // ربط المستخدم
    public int UserId { get; set; }

    private Transaction() { }

    public static Transaction Create(
         decimal amount,
            TransactionType type,
            PaymentMethod paymentMethod,
            int userId,
            string description = null,
            int? purchaseInvoiceId = null,
            int? salesInvoiceId = null
        )
    {
        if (amount <= 0) { 
        throw new ArgumentException("Amount must be greater than zero.");
        }
        if(userId<= 0)
        {
            throw new ArgumentException("Invalid User ID.");
        }
        return new Transaction
        {
            Date = DateTime.UtcNow,
            Amount = amount,
            Type = type,
            PaymentMethod = paymentMethod,
            UserId = userId,
            Description = description,
            PurchaseInvoiceId = purchaseInvoiceId,
            SalesInvoiceId = salesInvoiceId
        };
    }
    public void UpdateTransaction(
         decimal amount,
            TransactionType type,
            PaymentMethod paymentMethod,
            string description = null,
            int? purchaseInvoiceId = null,
            int? salesInvoiceId = null
        )
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }
        Amount = amount;
        Type = type;
        PaymentMethod = paymentMethod;
        Description = description;
        PurchaseInvoiceId = purchaseInvoiceId;
        SalesInvoiceId = salesInvoiceId;
    }
    public void UpdateAmount(decimal newAmount)
    {
        if (newAmount <= 0)
            throw new ArgumentException("Amount must be greater than zero");

        Amount = newAmount;
    }
    public void UpdateDescription(string newDescription)
    {
        Description = newDescription;
    }

}
public enum TransactionType
{
    Purchase,   // شراء
    Sale,       // بيع
    Expense,    // مصروف
    Production, // عملية إنتاج
    Adjustment  // تعديل مخزون أو قيود
}
public enum PaymentMethod
{
    Cash,
    Bank,
    Credit
}
