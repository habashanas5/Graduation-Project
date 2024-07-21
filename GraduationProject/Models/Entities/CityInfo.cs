using GraduationProject.Models.Contracts;

namespace GraduationProject.Models.Entities
{
    public class CityInfo : _Base
    {
        public long Id { get; set; }
        public string CityName { get; set; }
        public string CityAscii { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public string Country { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string AdminName { get; set; }
        public string Capital { get; set; }
        public long Population { get; set; }
    }
}
