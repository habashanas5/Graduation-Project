using Microsoft.AspNetCore.Mvc.Rendering;

namespace GraduationProject.Infrastructures.TimeZones
{
    public interface ITimeZoneService
    {
        ICollection<SelectListItem> GetAllTimeZones();
    }
}
