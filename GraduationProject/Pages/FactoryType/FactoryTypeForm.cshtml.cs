using AutoMapper;
using GraduationProject.Applications.VendorGroups;
using GraduationProject.Infrastructures.Extensions;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace GraduationProject.Pages.FactoryType
{
    [Authorize(Roles = "Admin")]
    public class VendorGroupFormModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly VendorGroupService _vendorGroupService;
        public VendorGroupFormModel(
            IMapper mapper,
            VendorGroupService vendorGroupService
            )
        {
            _mapper = mapper;
            _vendorGroupService = vendorGroupService;
        }

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;
        public string? Action { get; set; } = string.Empty;

        [BindProperty]
        public VendorGroupModel VendorGroupForm { get; set; } = default!;

        public class VendorGroupModel
        {
            public Guid? RowGuid { get; set; }

            [DisplayName("Name")]
            public string Name { get; set; } = string.Empty;

            [DisplayName("Description")]
            public string? Description { get; set; }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<FactoriesType, VendorGroupModel>();
                CreateMap<VendorGroupModel, FactoriesType>();
            }
        }

        private void BindLookup()
        {

        }

        public async Task OnGetAsync(Guid? rowGuid)
        {

            this.SetupViewDataTitleFromUrl();
            this.SetupStatusMessage();
            StatusMessage = this.ReadStatusMessage();

            var action = Request.Query["action"];
            Action = action;

            BindLookup();

            if (rowGuid.HasValue)
            {
                var existing = await _vendorGroupService.GetByRowGuidAsync(rowGuid);
                if (existing == null)
                {
                    throw new Exception($"Unable to load: {rowGuid}");
                }
                VendorGroupForm = _mapper.Map<VendorGroupModel>(existing);
            }
            else
            {
                VendorGroupForm = new VendorGroupModel
                {
                    RowGuid = Guid.Empty
                };
            }
        }

        public async Task<IActionResult> OnPostAsync([Bind(Prefix = nameof(VendorGroupForm))] VendorGroupModel input)
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
                var newobj = _mapper.Map<FactoriesType>(input);
                await _vendorGroupService.AddAsync(newobj);

                this.WriteStatusMessage($"Success create new data.");
                return Redirect("./FactoryClassificationList");

            }
            else if (action == "edit")
            {
                var existing = await _vendorGroupService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                _mapper.Map(input, existing);
                await _vendorGroupService.UpdateAsync(existing);

                this.WriteStatusMessage($"Success update existing data.");
                return Redirect("./FactoryClassificationList");

            }
            else if (action == "delete")
            {
                var existing = await _vendorGroupService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                await _vendorGroupService.DeleteByRowGuidAsync(input.RowGuid);

                this.WriteStatusMessage($"Success delete existing data.");
                return Redirect("./FactoryClassificationList");
            }
            return Page();
        }

    }
}
