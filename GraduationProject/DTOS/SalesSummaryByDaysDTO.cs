namespace GraduationProject.DTOS
{
    public class SalesSummaryByDaysDTO
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int NumberOfSales { get; set; }
        public int NumberOfProductSold { get; set; }
        public Guid? RowGuid { get; set; }
        public DateTime? CreatedAtUtc { get; set; }
    }
}
