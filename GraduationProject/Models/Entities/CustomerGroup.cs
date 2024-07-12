using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class CustomerGroup : _Base
    {
        public CustomerGroup() { }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
