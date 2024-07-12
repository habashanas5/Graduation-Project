using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class ProductGroup : _Base
    {
        public ProductGroup() { }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public byte[]? ImageData { get; set; } 
        public string? ImageFileName { get; set; } 

    }

}