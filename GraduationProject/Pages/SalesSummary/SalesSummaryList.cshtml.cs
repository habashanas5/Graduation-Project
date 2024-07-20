using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using GraduationProject.Infrastructures.Extensions;


namespace GraduationProject.Pages.SalesSummary
{
    [Authorize(Roles = "Admin")]
    public class SalesSummaryListModel : PageModel
    {
        public SalesSummaryListModel() { }

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
