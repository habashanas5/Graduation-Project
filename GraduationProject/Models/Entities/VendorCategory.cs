using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class VendorCategory : _Base
    {
        public VendorCategory() { }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
