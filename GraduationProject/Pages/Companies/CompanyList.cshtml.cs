using GraduationProject.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.Companies
{
    [Authorize(Roles = "Admin")]
    public class CompanyListModel : PageModel
    {
        public CompanyListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();

        }
    }
}
