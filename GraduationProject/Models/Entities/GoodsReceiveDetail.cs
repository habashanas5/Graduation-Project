using GraduationProject.Models.Contracts;
using GraduationProject.Models.Entity;

namespace GraduationProject.Models.Entities
{
    public class GoodsReceiveDetail : _Base
    {
        public GoodsReceiveDetail() { }
        public required int GoodsReceiveId { get; set; }
        public GoodsReceive? GoodsReceive { get; set; }
        public required int ProductId { get; set; }
        public Product? Product { get; set; }
        public required int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
        public required int Quantity { get; set; }
    }
}
