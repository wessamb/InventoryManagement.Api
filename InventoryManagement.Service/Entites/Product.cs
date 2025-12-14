namespace InventoryManagement.Application.Entites
{
    public class Product
    {
        public int ProductId { get; set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public string Name { get; set; }
        public decimal SellingPrice { get; set; }
        public string Barcode { get; set; }

        public ICollection<BOM> BOMs { get; set; } = new List<BOM>();
        public ICollection<ProductionOrder> ProductionOrders { get; set; } = new List<ProductionOrder>();
        public ICollection<SalesInvoiceItem> SalesItems { get; set; } = new List<SalesInvoiceItem>();
        public ICollection<InventoryRecord> InventoryRecords { get; set; } = new List<InventoryRecord>();
    }
}
