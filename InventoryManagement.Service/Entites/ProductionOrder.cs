using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Entites
{
   public  class ProductionOrder
    {
        public int ProductionOrderId { get; set; }      // معرف أمر الإنتاج
        public int ProductId { get; set; }              // FK → المنتج النهائي
        public Product Product { get; set; }            // علاقة مع المنتج
        public int QuantityToProduce { get; set; }      // كمية المنتج المراد إنتاجها
        public string Status { get; set; }              // Pending / InProgress / Completed / Cancelled
        public double WasteQuantity { get; set; }       // كمية الفاقد أثناء الإنتاج
        public decimal ProductionCost { get; set; }     // التكلفة الكلية للإنتاج
        public int CreatedBy { get; set; }              // المستخدم المسؤول
        public User User { get; set; }                  // علاقة مع المستخدم
        public DateTime? StartDate { get; set; }        // وقت بدء الإنتاج
        public DateTime? EndDate { get; set; }
        public ICollection<ProductionOrderItem> Items { get; set; } = new List<ProductionOrderItem>();


        public ICollection<Transaction> Transactions { get; set; }


    }
}
