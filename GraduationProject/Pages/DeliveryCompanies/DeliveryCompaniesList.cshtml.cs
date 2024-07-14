using GraduationProject;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GraduationProject.Applications.DeliveryCompanys;
using Microsoft.AspNetCore.Authorization;

namespace GraduationProject.Pages.DeliveryCompanies
{
    [Authorize(Roles = "Admin")]
    public class DeliveryCompaniesListModel : PageModel
    {
        private readonly IDeliveryCompanyService _deliveryCompanyService;

        public DeliveryCompaniesListModel(IDeliveryCompanyService deliveryCompanyService)
        {
            _deliveryCompanyService = deliveryCompanyService;
        }

        public List<DeliveryCompanyDto> DeliveryCompanies { get; set; }
        public string StatusMessage { get; set; }

        public async Task OnGetAsync()
        {
            var companies = await _deliveryCompanyService.GetAllDeliveryCompaniesAsync();
            DeliveryCompanies = companies.Select(dc => new DeliveryCompanyDto
            {
                Id = dc.Id,
                Name = dc.Name,
                ContactNumber = dc.ContactNumber,
                Email = dc.Email,
                Address = dc.Address,
                RowGuid = dc.RowGuid,
                CreatedAtUtc = dc.CreatedAtUtc
            }).ToList();
            StatusMessage = "Data loaded successfully!";
        }
    }
}
