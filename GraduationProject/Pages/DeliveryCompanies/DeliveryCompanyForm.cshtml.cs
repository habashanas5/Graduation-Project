using AutoMapper;
using GraduationProject.Applications.DeliveryCompanys;
using GraduationProject.Applications.NumberSequences;
using GraduationProject.Infrastructures.Extensions;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace GraduationProject.Pages.DeliveryCompanies
{
    [Authorize(Roles = "Admin")]
    public class DeliveryCompanyFormModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly DeliveryCompanyService _deliveryCompanyService;
       
        public DeliveryCompanyFormModel(
              IMapper mapper,
            DeliveryCompanyService deliveryCompanyService
            )
        {
            _mapper = mapper;
            _deliveryCompanyService = deliveryCompanyService;
        }

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;
        public string? Action { get; set; } = string.Empty;

        [BindProperty]
        public DeliveryCompanyModel DeliveryCompanyForm { get; set; } = default!;

        public class DeliveryCompanyModel
        {
            public Guid? RowGuid { get; set; }

            [DisplayName("Name")]
            public string Name { get; set; } = string.Empty;

            [DisplayName("Contact Number")]
            public string? ContactNumber { get; set; }

            [DisplayName("Email")]
            public string? Email { get; set; }

            [DisplayName("Address")]
            public string? Address { get; set; }      

        }
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<DeliveryCompany, DeliveryCompanyModel>();
                CreateMap<DeliveryCompanyModel, DeliveryCompany>();
            }
        }

        public async Task OnGetAsync(Guid? rowGuid)
        {
            this.SetupViewDataTitleFromUrl();
            this.SetupStatusMessage();
            StatusMessage = this.ReadStatusMessage();

            var action = Request.Query["action"];
            Action = action;

            if (rowGuid.HasValue)
            {
                var existing = await _deliveryCompanyService.GetByRowGuidAsync(rowGuid);
                if (existing == null)
                {
                    throw new Exception($"Unable to load: {rowGuid}");
                }
                DeliveryCompanyForm = _mapper.Map<DeliveryCompanyModel>(existing);
            }
            else
            {
                DeliveryCompanyForm = new DeliveryCompanyModel
                {
                    RowGuid = Guid.Empty
                };
            }
        }
        public async Task<IActionResult> OnPostAsync([Bind(Prefix = nameof(DeliveryCompanyForm))] DeliveryCompanyModel input)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" ", ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
                throw new Exception(message);
            }

            var action = "create";

            if (!string.IsNullOrEmpty(Request.Query["action"]))
            {
                action = Request.Query["action"];
            }

            if (action == "create")
            {
                var newObj = _mapper.Map<DeliveryCompany>(input);

                await _deliveryCompanyService.AddAsync(newObj);

                this.WriteStatusMessage($"Success create new data.");
                return Redirect("./DeliveryCompanyList");
            }
            else if (action == "edit")
            {
                var existing = await _deliveryCompanyService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                _mapper.Map(input, existing);

                await _deliveryCompanyService.UpdateAsync(existing);

                this.WriteStatusMessage($"Success update existing data.");
                return Redirect("./DeliveryCompanyList");
            }
            else if (action == "delete")
            {
                var existing = await _deliveryCompanyService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                await _deliveryCompanyService.DeleteByRowGuidAsync(input.RowGuid);

                this.WriteStatusMessage($"Success delete existing data.");
                return Redirect("./DeliveryCompanyList");
            }
            return Page();
        }
    }
}