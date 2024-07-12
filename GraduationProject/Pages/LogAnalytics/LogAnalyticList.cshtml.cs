using GraduationProject.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.LogAnalytics
{
    [Authorize(Roles = "Admin")]
    public class LogAnalyticListModel : PageModel
    {
        public LogAnalyticListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }

    }
}
