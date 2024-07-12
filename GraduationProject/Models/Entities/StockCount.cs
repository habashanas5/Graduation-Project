using GraduationProject.Models.Contracts;
using GraduationProject.Models.Entity;
using GraduationProject.Models.Enums;

namespace GraduationProject.Models.Entities
{
    public class StockCount : _Base
    {
        public StockCount() { }
        public string? Number { get; set; }
        public DateTime? CountDate { get; set; }
        public StockCountStatus? Status { get; set; }
        public string? Description { get; set; }
        public required int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
