using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class ManufacturingOrdersItems : _Base 
    {
        public ManufacturingOrdersItems() { }
        public required int PurchaseOrderId { get; set; }
        public ManufacturingOrdersTable? PurchaseOrder { get; set; }
        public required int ProductId { get; set; }
        public Product? Product { get; set; }
        public string? Summary { get; set; }
        public double? UnitPrice { get; set; } = 0;
        public double? Quantity { get; set; } = 1;
        public double? Total { get; set; } = 0;

        public void RecalculateTotal()
        {
            Total = Quantity * UnitPrice;
        }
    }
}
