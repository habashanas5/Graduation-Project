using GraduationProject.Applications.Companies;
using GraduationProject.Infrastructures.Countries;
using GraduationProject.Infrastructures.Currencies;
using GraduationProject.Infrastructures.TimeZones;
using GraduationProject.Models.Entities;

namespace GraduationProject.Data.System
{
    public static class DefaultCompany
    {
        public static async Task GenerateAsync(
            CompanyService? companyService,
            ICurrencyService? currencyService,
            ITimeZoneService? timezoneService,
            ICountryService? countryService,
            ApplicationUser? creator
            )
        {
            if (companyService != null)
            {

                var defaultCompany = new Company
                {
                    Name = "Forked spider Company",
                    Currency = currencyService?.GetCurrencies().FirstOrDefault(x => x.Value.Equals("US$"))?.Value ?? "US$",
                    TimeZone = timezoneService?.GetAllTimeZones().FirstOrDefault(x => x.Value.Equals("SE Asia Standard Time"))?.Value ?? "SE Asia Standard Time",
                    Street = "456 Oak Avenue",
                    City = "Chicago",
                    State = "Illinois (IL)",
                    ZipCode = "60601",
                    Country = countryService?.GetCountries().FirstOrDefault(x => x.Value.Equals("United States"))?.Value ?? "United States",
                    CreatedByUserId = creator?.Id

                };

                await companyService.AddAsync(defaultCompany);

            }
        }
    }
}
