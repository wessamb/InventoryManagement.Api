using InventoryManagement.Application.Entites;


public class Inventory
{
    public int InventoryID { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Unit { get; set; }
    public decimal AverageCost { get; set; }
    public decimal QuantityOnHand { get; set; }

    public Product Products { get; set; }
    public ICollection<BOM> BOMs { get; set; } = new List<BOM>();
    public ICollection<PurchaseInvoiceItem> PurchaseItems { get; set; } = new List<PurchaseInvoiceItem>();
    public ICollection<ProductionOrderItem> ProductionOrderItem { get; set; } = new List<ProductionOrderItem>();
}