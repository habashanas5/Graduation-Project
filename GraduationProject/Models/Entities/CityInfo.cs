using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class CityInfo : _Base
    {
        public int Id { get; set; }
        public required string CityName { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public required string Country { get; set; }
        public int? Population { get; set; }
    }
}
