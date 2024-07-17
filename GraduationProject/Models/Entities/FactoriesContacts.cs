using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class FactoriesContacts : _Base
    {
        public FactoriesContacts() { }
        public required string Name { get; set; }
        public string? Number { get; set; }
        public string? JobTitle { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? Description { get; set; }
        public required int FactorysId { get; set; }
        public Factory? Factory { get; set; }
    }
}
