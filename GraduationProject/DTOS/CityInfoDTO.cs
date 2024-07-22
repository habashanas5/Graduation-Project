namespace GraduationProject.DTOS
{
    public class CityInfoDTO
    {
        public int? Id { get; set; }
        public string? CityName { get; set; }
        public string? CityAscii { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }
        public string? Country { get; set; }
        public string? Iso2 { get; set; }
        public string? Iso3 { get; set; }
        public string? AdminName { get; set; }
        public string? Capital { get; set; }
        public int? Population { get; set; }
        public Guid? RowGuid { get; set; }
        public DateTime? CreatedAtUtc { get; set; }
    }
}
