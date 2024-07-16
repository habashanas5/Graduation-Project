using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class FactoriesType : _Base
    {
        public FactoriesType() { }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
