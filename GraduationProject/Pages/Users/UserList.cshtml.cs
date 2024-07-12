using GraduationProject.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.Users
{
    [Authorize(Roles = "Admin")]

    public class UserListModel : PageModel
    {
        public UserListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }
    }
}
