using InventoryManagement.Application.Entites;
using InventoryManagement.Domain.Entites;


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

    public ICollection<InventoryTransaction> inventoryTransactions { get; set; } = new List<InventoryTransaction>();
    
    public ICollection<ProductionOrderItem> ProductionOrderItem { get; set; } = new List<ProductionOrderItem>();
}