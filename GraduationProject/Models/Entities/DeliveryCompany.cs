using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class DeliveryCompany : _Base
    {
        public DeliveryCompany()
        {
            DeliveryOrders = new HashSet<DeliveryOrder>();
        }

        public string Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public ICollection<DeliveryOrder> DeliveryOrders { get; set; }
    }
}
