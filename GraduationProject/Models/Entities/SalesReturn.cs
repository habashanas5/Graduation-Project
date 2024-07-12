using GraduationProject.Models.Contracts;
using GraduationProject.Models.Enums;

namespace GraduationProject.Models.Entities
{
    public class SalesReturn : _Base
    {
        public SalesReturn() { }
        public string? Number { get; set; }
        public DateTime? ReturnDate { get; set; }
        public SalesReturnStatus? Status { get; set; }
        public string? Description { get; set; }
        public required int DeliveryOrderId { get; set; }
        public DeliveryOrder? DeliveryOrder { get; set; }
    }
}
