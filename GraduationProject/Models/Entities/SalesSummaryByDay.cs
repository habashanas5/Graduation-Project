using GraduationProject.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models.Entities
{
    public class SalesSummaryByDay :  _Base
    {
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public Product? Products { get; set; }
        public string? ProductName { get; set; }
        public int NumberOfSales { get; set; }
        public int NumberOfProductSold { get; set; }
    }
}
