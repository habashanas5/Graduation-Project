using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class FactoriesClassification : _Base
    {
        public FactoriesClassification() { }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
