using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class Factorys : _Base
    {
        public Factorys() { }
        public required string Name { get; set; }
        public string? Number { get; set; }
        public string? Description { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }
        public string? EmailAddress { get; set; }
        public int? Ranking { get; set; }
        public string? Website { get; set; }
        public required int VendorGroupId { get; set; }
        public FactoriesType? VendorGroup { get; set; }
        public required int VendorCategoryId { get; set; }
        public FactoriesClassification? VendorCategory { get; set; }
    }
}
