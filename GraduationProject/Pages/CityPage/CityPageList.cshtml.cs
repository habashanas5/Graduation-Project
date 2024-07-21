using GraduationProject.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.CityPage
{
    [Authorize(Roles = "Admin")]
    public class CityPageListModel : PageModel
    {
        public CityPageListModel() { }

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;
        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
            this.SetupStatusMessage();
            StatusMessage = this.ReadStatusMessage();
        }
    }
}
