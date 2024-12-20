using AutoMapper;
using GraduationProject.Applications.DeliveryCompanys;
using GraduationProject.Applications.DeliveryOrders;
using GraduationProject.Applications.InventoryTransactions;
using GraduationProject.Applications.NumberSequences;
using GraduationProject.Applications.Products;
using GraduationProject.Applications.SalesOrders;
using GraduationProject.Applications.Warehouses;
using GraduationProject.Infrastructures.Extensions;
using GraduationProject.Models.Entities;
using GraduationProject.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.ComponentModel;

namespace GraduationProject.Pages.DeliveryOrders
{
    [Authorize(Roles = "Admin")]
    public class DeliveryOrderFormModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly DeliveryOrderService _deliveryOrderService;
        private readonly NumberSequenceService _numberSequenceService;
        private readonly SalesOrderService _salesOrderService;
        private readonly ProductService _productService;
        private readonly WarehouseService _warehouseService;
        private readonly InventoryTransactionService _inventoryTransactionService;
        private readonly DeliveryCompanyService _deliveryCompanyService;
        private readonly IEmailSender _emailSender;

        public DeliveryOrderFormModel(
            IMapper mapper,
            DeliveryOrderService deliveryOrderService,
            NumberSequenceService numberSequenceService,
            SalesOrderService salesOrderService,
            ProductService productService,
            WarehouseService warehouseService,
            InventoryTransactionService inventoryTransactionService,
            DeliveryCompanyService deliveryCompanyService,
            IEmailSender emailSender
            )
        {
            _mapper = mapper;
            _deliveryOrderService = deliveryOrderService;
            _numberSequenceService = numberSequenceService;
            _salesOrderService = salesOrderService;
            _productService = productService;
            _warehouseService = warehouseService;
            _inventoryTransactionService = inventoryTransactionService;
            _deliveryCompanyService = deliveryCompanyService;
            _emailSender = emailSender;

        }

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;
        public string? Action { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;

        [BindProperty]
        public DeliveryOrderModel DeliveryOrderForm { get; set; } = default!;

        public class DeliveryOrderModel
        {
            public Guid? RowGuid { get; set; }
            public int? Id { get; set; }

            [DisplayName("Delivery Date")]
            public DateTime DeliveryDate { get; set; } = DateTime.Now;

            [DisplayName("Order Status")]
            public DeliveryOrderStatus Status { get; set; }

            [DisplayName("Description")]
            public string? Description { get; set; }

            [DisplayName("Sales Order")]
            public int SalesOrderId { get; set; }

            [DisplayName("Delivery Company")]
            public int DeliveryCompanyId { get; set; } 
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<DeliveryOrder, DeliveryOrderModel>();
                CreateMap<DeliveryOrderModel, DeliveryOrder>();
            }
        }

        public ICollection<SelectListItem> SalesOrderLookup { get; set; } = default!;
        public ICollection<object> ProductLookup { get; set; } = default!;
        public ICollection<object> WarehouseLookup { get; set; } = default!;
        public ICollection<SelectListItem> DeliveryCompanyLookup { get; set; } = default!;

        private void BindLookup()
        {

            SalesOrderLookup = _salesOrderService
                .GetAll()
                .Include(x => x.Customer)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.Number} / {x.Customer!.Name}"
                }).ToList();


            ProductLookup = _productService.GetAll()
                .Select(x => new { ProductId = x.Id, ProductName = $"{x.Name}" } as object)
                .ToList();

            WarehouseLookup = _warehouseService.GetAll().Where(x => x.IsDefault == false)
                .Select(x => new { WarehouseId = x.Id, WarehouseName = x.Name } as object)
                .ToList();

            DeliveryCompanyLookup = _deliveryCompanyService.GetAllDeliveryCompanies()
       .Select(dc => new SelectListItem
       {
           Value = dc.Id.ToString(),
           Text = dc.Name
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
                var existing = await _deliveryOrderService.GetByRowGuidAsync(rowGuid);
                if (existing == null)
                {
                    throw new Exception($"Unable to load: {rowGuid}");
                }
                DeliveryOrderForm = _mapper.Map<DeliveryOrderModel>(existing);
                Number = existing.Number ?? string.Empty;
            }
            else
            {
                DeliveryOrderForm = new DeliveryOrderModel
                {
                    RowGuid = Guid.Empty,
                    Id = 0
                };
            }
        }

        public async Task<IActionResult> OnPostAsync([Bind(Prefix = nameof(DeliveryOrderForm))] DeliveryOrderModel input)
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
                var newobj = _mapper.Map<DeliveryOrder>(input);

                Number = _numberSequenceService.GenerateNumber(nameof(DeliveryOrder), "", "DO");
                newobj.Number = Number;

                var selectedCompany = await _deliveryCompanyService.GetDeliveryCompanyByIdAsync(input.DeliveryCompanyId);
                newobj.DeliveryCompany = selectedCompany;

                await _deliveryOrderService.AddAsync(newobj);

                var salesOrder = await _salesOrderService.GetByIdAsync(input.SalesOrderId);
                var emailMessage = $"New Order \n\n" +
                    $"Sales Order Number: {salesOrder.Number} \n\n" +
                    $"Delivery Date: {input.DeliveryDate.ToShortDateString()} \n\n" +
                    $"Description: {input.Description}";

                await _emailSender.SendEmailAsync(selectedCompany.Email, "New Order", emailMessage);

                this.WriteStatusMessage($"Success create new data.");
                return Redirect($"./DeliveryOrderForm?rowGuid={newobj.RowGuid}&action=edit");
            }
            else if (action == "edit")
            {
                var existing = await _deliveryOrderService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                _mapper.Map(input, existing);
                await _deliveryOrderService.UpdateAsync(existing);

                var childs = await _inventoryTransactionService
                    .GetAll()
                    .Where(x => x.ModuleId == existing.Id && x.ModuleName == nameof(DeliveryOrder))
                    .ToListAsync();

                foreach (var item in childs)
                {
                    item.ModuleNumber = existing.Number!;
                    item.MovementDate = existing.DeliveryDate!.Value;
                    item.Status = (InventoryTransactionStatus)existing.Status!;

                    await _inventoryTransactionService.UpdateAsync(item);
                }

                this.WriteStatusMessage($"Success update existing data.");
                return Redirect($"./DeliveryOrderForm?rowGuid={existing.RowGuid}&action=edit");
            }
            else if (action == "delete")
            {
                var existing = await _deliveryOrderService.GetByRowGuidAsync(input.RowGuid);
                if (existing == null)
                {
                    var message = $"Unable to load existing data: {input.RowGuid}";
                    throw new Exception(message);
                }

                await _deliveryOrderService.DeleteByRowGuidAsync(input.RowGuid);

                this.WriteStatusMessage($"Success delete existing data.");
                return Redirect("./DeliveryOrderList");
            }
            return Page();
        }

    }
}
