using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class Product : _Base
    {
        public Product() { }
        public required string Name { get; set; }
        public string? Number { get; set; }
        public string? Description { get; set; }
        public required double UnitPrice { get; set; }
        public bool Physical { get; set; } = true;
        public required int UnitMeasureId { get; set; }
        public UnitMeasure? UnitMeasure { get; set; }
        public required int ProductGroupId { get; set; }
        public ProductGroup? ProductGroup { get; set; }
        public int? rating { get; set; }
        public double RatingAverage { get; set; }
        public double oldPrice { get; set; }
        public string? MetaKeyWords { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageFileName { get; set; }
        public ICollection<WarehouseProduct>? WarehouseProducts { get; set; }    

    }
}
