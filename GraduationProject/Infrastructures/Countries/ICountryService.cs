using Microsoft.AspNetCore.Mvc.Rendering;

namespace GraduationProject.Infrastructures.Countries
{
    public interface ICountryService
    {
        ICollection<SelectListItem> GetCountries();
    }
}
