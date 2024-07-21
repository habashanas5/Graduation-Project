using AutoMapper;
using GraduationProject.Applications.Customers;
using GraduationProject.Applications.DeliveryCompanys;
using GraduationProject.Applications.ProductGroups;
using GraduationProject.Applications.Products;
using GraduationProject.Applications.SalesSummaryByDays;
using GraduationProject.Infrastructures.Extensions;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using static GraduationProject.Pages.Customers.CustomerFormModel;
using static GraduationProject.Pages.DeliveryCompanies.DeliveryCompaniesFormModel;
using static GraduationProject.Pages.Products.ProductFormModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GraduationProject.Pages.SalesSummary
{
    [Authorize(Roles = "Admin")]
    public class SalesSummaryFormModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly SalesSummaryByDayService _salesSummaryByDayService;
        private readonly ProductService _productService;


        public SalesSummaryFormModel (
            IMapper mapper, 
            SalesSummaryByDayService salesSummaryByDayService,
            ProductService productService
            )
        {
            _mapper = mapper;
            _salesSummaryByDayService = salesSummaryByDayService;
            _productService = productService;
        }

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;
        public string? Action { get; set; } = string.Empty;

        [BindProperty]
        public SalesSummaryByDayModel SalesSummaryByDayForm { get; set; } = default!;

        public class SalesSummaryByDayModel
        {
            public Guid? RowGuid { get; set; }

            [DisplayName("Product Number")]
            public int ProductId { get; set; }

            [DisplayName("Product Name")]
            public string? ProductName { get; set; }

            [DisplayName("Number of Prodcut Sold")]
            public int NumberOfProductSold { get; set; }

            [DisplayName("Number of Sales")]
            public int NumberOfSales { get; set; }

        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<SalesSummaryByDay, SalesSummaryByDayModel>();
                CreateMap<SalesSummaryByDayModel, SalesSummaryByDay>();
            }
        }

        public ICollection<SelectListItem> ProductLookup { get; set; } = default!;

        private void BindLookup()
        {
            ProductLookup = _productService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.Name}"
            }).ToList();
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
                var existing = await _salesSummaryByDayService.GetByRowGuidAsync(rowGuid);
                if (existing == null)
                {
                    throw new Exception($"Unable to load: {rowGuid}");
                }
                SalesSummaryByDayForm = _mapper.Map<SalesSummaryByDayModel>(existing);
            }
            else
            {
                SalesSummaryByDayForm = new SalesSummaryByDayModel
                {
                    RowGuid = Guid.Empty,
                };
            }
        }
        public async Task<IActionResult> OnPostAsync([Bind(Prefix = nameof(SalesSummaryByDayForm))] SalesSummaryByDayModel input)
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
                var newObj = _mapper.Map<SalesSummaryByDay>(input);

                await _salesSummaryByDayService.AddAsync(newObj);

                this.WriteStatusMessage($"Success create new data.");
                return Redirect("./SalesSummaryList");
            }

            else if (action == "edit")
            {
                var existing = await _salesSummaryByDayService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                _mapper.Map(input, existing);


                await _salesSummaryByDayService.UpdateAsync(existing);

                this.WriteStatusMessage($"Success update existing data.");
                return Redirect("./SalesSummaryList");

            }

            else if (action == "delete")
            {
                var existing = await _salesSummaryByDayService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                await _salesSummaryByDayService.DeleteByRowGuidAsync(input.RowGuid);

                this.WriteStatusMessage($"Success delete existing data.");
                return Redirect("./SalesSummaryList");
            }

            return Page();
        }
    }
}
