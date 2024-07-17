namespace GraduationProject.DTOS
{
    public class FactoriesContactChildDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? JobTitle { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public int? FactoryId { get; set; }
        public Guid? RowGuid { get; set; }
    }
}
