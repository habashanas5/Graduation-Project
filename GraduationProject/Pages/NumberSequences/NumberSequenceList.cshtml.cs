using GraduationProject.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.NumberSequences
{
    [Authorize(Roles = "Admin")]
    public class NumberSequenceListModel : PageModel
    {
        public NumberSequenceListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }

    }
}
