using GraduationProject.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.LogErrors
{
    [Authorize(Roles = "Admin")]
    public class LogErrorListModel : PageModel
    {
        public LogErrorListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }

    }
}
