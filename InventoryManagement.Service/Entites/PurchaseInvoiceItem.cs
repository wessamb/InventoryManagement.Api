    namespace InventoryManagement.Domain.Entities
    {
        public class PurchaseInvoiceItem
        {
            public int Id { get; private set; }

            public int InventoryId { get; private set; }
            public decimal Quantity { get; private set; }
            public decimal UnitPrice { get; private set; }

            public decimal TotalPrice => Quantity * UnitPrice;

            internal PurchaseInvoiceItem(int inventoryId, decimal quantity, decimal unitPrice)
            {
                if (quantity <= 0)
                    throw new ArgumentException("Quantity must be greater than zero");

                if (unitPrice <= 0)
                    throw new ArgumentException("Unit price must be greater than zero");

                InventoryId = inventoryId;
                Quantity = quantity;
                UnitPrice = unitPrice;
            }

            internal void UpdateQuantity(decimal quantity)
            {
                if (quantity <= 0)
                    throw new ArgumentException("Quantity must be greater than zero");

                Quantity = quantity;
            }

            internal void UpdateUnitPrice(decimal unitPrice)
            {
                if (unitPrice <= 0)
                    throw new ArgumentException("Unit price must be greater than zero");

                UnitPrice = unitPrice;
            }
        }
    }
