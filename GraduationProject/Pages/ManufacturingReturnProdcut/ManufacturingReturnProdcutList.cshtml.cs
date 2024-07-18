using GraduationProject.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.ManufacturingReturnProdcut
{
    [Authorize(Roles = "Admin")]
    public class ManufacturingReturnProdcutListModel : PageModel
    {
        public ManufacturingReturnProdcutListModel() { }

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
