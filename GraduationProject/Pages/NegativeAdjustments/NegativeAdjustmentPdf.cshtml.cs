using GraduationProject.Applications.AdjustmentMinuss;
using GraduationProject.Applications.Companies;
using GraduationProject.Applications.InventoryTransactions;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Pages.NegativeAdjustments
{
    public class NegativeAdjustmentPdfModel : PageModel
    {
        private readonly AdjustmentMinusService _adjustmentMinusService;
        private readonly InventoryTransactionService _inventoryTransactionService;
        private readonly CompanyService _companyService;
        public NegativeAdjustmentPdfModel(
            AdjustmentMinusService adjustmentMinusService,
            InventoryTransactionService inventoryTransactionService,
            CompanyService companyService)
        {
            _adjustmentMinusService = adjustmentMinusService;
            _inventoryTransactionService = inventoryTransactionService;
            _companyService = companyService;
        }

        public AdjustmentMinus? AdjustmentMinus { get; set; }
        public List<InventoryTransaction>? InventoryTransactions { get; set; }
        public Company? Company { get; set; }
        public string? CompanyAddress { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Company = await _companyService.GetDefaultCompanyAsync();

            CompanyAddress = string.Join(", ", new List<string>()
            {
                Company?.Street ?? string.Empty,
                Company?.City ?? string.Empty,
                Company?.State ?? string.Empty,
                Company?.Country ?? string.Empty,
                Company?.ZipCode ?? string.Empty
            }.Where(s => !string.IsNullOrEmpty(s)));

            AdjustmentMinus = await _adjustmentMinusService
                .GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            InventoryTransactions = await _inventoryTransactionService
                .GetAll()
                .Where(x => x.ModuleId == id && x.ModuleName == nameof(AdjustmentMinus))
                .Include(x => x.Warehouse)
                .Include(x => x.Product)
                    .ThenInclude(x => x!.UnitMeasure)
                .ToListAsync();

        }
    }
}
