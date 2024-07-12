using GraduationProject.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.LogSessions
{
    [Authorize(Roles = "Admin")]
    public class LogSessionListModel : PageModel
    {
        public LogSessionListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }

    }
}
