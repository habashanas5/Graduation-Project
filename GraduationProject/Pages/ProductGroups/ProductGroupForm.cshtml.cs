using AutoMapper;
using GraduationProject.Applications.ProductGroups;
using GraduationProject.Infrastructures.Extensions;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Drawing;

namespace GraduationProject.Pages.ProductGroups
{
    [Authorize(Roles = "Admin")]
    public class ProductGroupFormModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ProductGroupService _productGroupService;
        public ProductGroupFormModel(
            IMapper mapper,
            ProductGroupService productGroupService
            )
        {
            _mapper = mapper;
            _productGroupService = productGroupService;
        }

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;
        public string? Action { get; set; } = string.Empty;

        [BindProperty]
        public ProductGroupModel ProductGroupForm { get; set; } = default!;

        public class ProductGroupModel
        {
            public Guid? RowGuid { get; set; }

            [DisplayName("Name")]
            public string Name { get; set; } = string.Empty;

            [DisplayName("Description")]
            public string? Description { get; set; }

            [DisplayName("Image Path")]
            public IFormFile? ImageUpload { get; set; } = default!;

            public byte[]? ImageData { get; set; } = default!;

            public string? ImageFileName { get; set; } = default!;
        }
        
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<ProductGroup, ProductGroupModel>();
                CreateMap<ProductGroupModel, ProductGroup>();
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
                var existing = await _productGroupService.GetByRowGuidAsync(rowGuid);
                if (existing == null)
                {
                    throw new Exception($"Unable to load: {rowGuid}");
                }
                ProductGroupForm = _mapper.Map<ProductGroupModel>(existing);
            }
            else
            {
                ProductGroupForm = new ProductGroupModel
                {
                    RowGuid = Guid.Empty
                };
            }
        }

        public async Task<IActionResult> OnPostAsync([Bind(Prefix = nameof(ProductGroupForm))] ProductGroupModel input)
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
            if (input.ImageUpload != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await input.ImageUpload.CopyToAsync(memoryStream);
                    input.ImageData = memoryStream.ToArray();
                    input.ImageFileName = input.ImageUpload.FileName; // Store file name
                }
            }

            if (action == "create")
            {
                var newobj = _mapper.Map<ProductGroup>(input);
                await _productGroupService.AddAsync(newobj);

                this.WriteStatusMessage($"Success create new data.");
                return Redirect("./ProductGroupList");
            }

            else if (action == "edit")
            {
                var existing = await _productGroupService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                _mapper.Map(input, existing);

                if (input.ImageData != null)
                {
                    existing.ImageData = input.ImageData;
                }

                await _productGroupService.UpdateAsync(existing);

                this.WriteStatusMessage($"Success update existing data.");
                return Redirect("./ProductGroupList");
            }
            else if (action == "delete")
            {
                var existing = await _productGroupService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                await _productGroupService.DeleteByRowGuidAsync(input.RowGuid);

                this.WriteStatusMessage($"Success delete existing data.");
                return Redirect("./ProductGroupList");
            }
            return Page();
        }

    }
}
