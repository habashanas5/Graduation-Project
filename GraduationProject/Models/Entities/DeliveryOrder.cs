using GraduationProject.Models.Contracts;
using GraduationProject.Models.Enums;

namespace GraduationProject.Models.Entities
{
    public class DeliveryOrder : _Base
    {
        public DeliveryOrder() { }
        public string? Number { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DeliveryOrderStatus? Status { get; set; }
        public string? Description { get; set; }
        public required int SalesOrderId { get; set; }
        public SalesOrder? SalesOrder { get; set; }
        public required int DeliveryCompanyId { get; set; }
        public DeliveryCompany? DeliveryCompany { get; set; }
    }
}
