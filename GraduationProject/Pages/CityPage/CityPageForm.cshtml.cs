using AutoMapper;
using GraduationProject.Applications.City;
using GraduationProject.Applications.SalesSummaryByDays;
using GraduationProject.Infrastructures.Extensions;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static GraduationProject.Pages.Products.ProductFormModel;
using static GraduationProject.Pages.SalesSummary.SalesSummaryFormModel;

namespace GraduationProject.Pages.CityPage
{
    [Authorize(Roles = "Admin")]
    public class CityPageFormModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly CityInfoService _cityInfoService;

        public CityPageFormModel(IMapper mapper, CityInfoService cityInfoService )
        {
            _mapper = mapper;
            _cityInfoService = cityInfoService;
        }

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;
        public string? Action { get; set; } = string.Empty;

        [BindProperty]
        public CityInfoModel CityInfoForm { get; set; } = default!;

        public class CityInfoModel
        {
            public Guid? RowGuid { get; set; }
            public string CityName { get; set; }
            public string CityAscii { get; set; }
            public decimal Lat { get; set; }
            public decimal Lng { get; set; }
            public string Country { get; set; }
            public string Iso2 { get; set; }
            public string Iso3 { get; set; }
            public string AdminName { get; set; }
            public string Capital { get; set; }
            public long Population { get; set; }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<CityInfo, CityInfoModel>();
                CreateMap<CityInfoModel, CityInfo>();
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
                var existing = await _cityInfoService.GetByRowGuidAsync(rowGuid);
                if (existing == null)
                {
                    throw new Exception($"Unable to load: {rowGuid}");
                }
                CityInfoForm = _mapper.Map<CityInfoModel>(existing);
            }
            else
            {
                CityInfoForm = new CityInfoModel
                {
                    RowGuid = Guid.Empty,
                };
            }
        }
        public async Task<IActionResult> OnPostAsync([Bind(Prefix = nameof(CityInfoForm))] CityInfoModel input)
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
                var newObj = _mapper.Map<CityInfo>(input);

                await _cityInfoService.AddAsync(newObj);

                this.WriteStatusMessage($"Success create new data.");
                return Redirect("./CityPageList");
            }

            else if (action == "edit")
            {
                var existing = await _cityInfoService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                _mapper.Map(input, existing);


                await _cityInfoService.UpdateAsync(existing);

                this.WriteStatusMessage($"Success update existing data.");
                return Redirect("./CityPageList");

            }

            else if (action == "delete")
            {
                var existing = await _cityInfoService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                await _cityInfoService.DeleteByRowGuidAsync(input.RowGuid);

                this.WriteStatusMessage($"Success delete existing data.");
                return Redirect("./CityPageList");
            }

            return Page();
        }
    }
}