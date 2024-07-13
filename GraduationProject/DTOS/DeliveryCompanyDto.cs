namespace GraduationProject.DTOS
{
    public class DeliveryCompanyDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime? CreatedAtUtc { get; set; }
    }
}
