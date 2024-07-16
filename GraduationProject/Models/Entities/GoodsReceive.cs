using GraduationProject.Models.Contracts;
using GraduationProject.Models.Enums;

namespace GraduationProject.Models.Entities
{
    public class GoodsReceive : _Base
    {
        public GoodsReceive() { }
        public string? Number { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public GoodsReceiveStatus? Status { get; set; }
        public string? Description { get; set; }
        public required int PurchaseOrderId { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        public ICollection<GoodsReceiveDetail>? GoodsReceiveDetails { get; set; }

    }
}
