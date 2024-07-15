using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class SalesReturnProduct : _Base
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string? Reason { get; set; }
        public int SalesReturnId { get; set; }
        public SalesReturn SalesReturn { get; set; }
        public int ProductId { get; set; } 
        public Product Product { get; set; } 
    }
}
