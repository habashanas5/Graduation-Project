using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace GraduationProject.Infrastructures.Countries
{
    public class CountryCoordinates 
    {
        private readonly string _geoJsonPath = "https://raw.githubusercontent.com/datasets/geo-countries/master/data/countries.geojson";

        public ICollection<SelectListItem> GetCountries()
        {
            List<SelectListItem> countries = new List<SelectListItem>();

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(_geoJsonPath);
                JObject geoJson = JObject.Parse(json);

                var features = geoJson["features"];

                foreach (var feature in features)
                {
                    string countryName = feature["properties"]["ADMIN"].ToString();
                    string isoA3 = feature["properties"]["ISO_A3"].ToString();

                    countries.Add(new SelectListItem { Text = countryName, Value = isoA3 });
                }
            }

            return countries.OrderBy(c => c.Text).ToList();
        }
    }
}