using Microsoft.AspNetCore.Mvc.Rendering;

namespace GraduationProject.Infrastructures.Currencies
{
    public interface ICurrencyService
    {
        ICollection<SelectListItem> GetCurrencies();
    }
}
