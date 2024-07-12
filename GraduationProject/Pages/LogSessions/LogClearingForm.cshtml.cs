using GraduationProject.Applications.LogSessions;
using GraduationProject.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.LogSessions
{
    [Authorize(Roles = "Admin")]
    public class LogClearingFormModel : PageModel
    {
        private readonly LogSessionService _logAnalyticService;
        public LogClearingFormModel(
            LogSessionService logAnalyticService
            )
        {
            _logAnalyticService = logAnalyticService;
        }

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
            this.SetupStatusMessage();
            StatusMessage = this.ReadStatusMessage();
        }

        public IActionResult OnPost()
        {

            var action = "create";

            if (!string.IsNullOrEmpty(Request.Query["action"]))
            {
                action = Request.Query["action"];
            }

            if (action == "purge")
            {
                _logAnalyticService.PurgeAllData();

                this.WriteStatusMessage($"Success purge all data.");
                //return RedirectToPage();
                return Redirect("./LogSessionList");
            }

            return Page();
        }

    }
}
