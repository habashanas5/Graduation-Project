using AutoMapper;
using GraduationProject.Applications.NumberSequences;
using GraduationProject.Applications.VendorCategories;
using GraduationProject.Applications.VendorGroups;
using GraduationProject.Applications.Vendors;
using GraduationProject.Infrastructures.Countries;
using GraduationProject.Infrastructures.Extensions;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace GraduationProject.Pages.Factory
{
    [Authorize(Roles = "Admin")]
    public class FactoriesListModel : PageModel
    {
        public FactoriesListModel() { }

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