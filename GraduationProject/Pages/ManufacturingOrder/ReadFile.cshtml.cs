using GraduationProject.Data;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.ManufacturingOrder
{
    public class ReadFileModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ReadFileModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IFormFile File { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (File == null || File.Length == 0)
            {
                ModelState.AddModelError("File", "Please select a valid file.");
                return Page();
            }

            var purchaseOrderItems = new List<ManufacturingOrdersItems>();

            try
            {
                using (var stream = new StreamReader(File.OpenReadStream()))
                {
                    while (!stream.EndOfStream)
                    {
                        var line = await stream.ReadLineAsync();
                        var values = line.Split(',');

                        var purchaseOrderItem = new ManufacturingOrdersItems
                        {
                            PurchaseOrderId = int.Parse(values[0]),
                            ProductId = int.Parse(values[1]),
                            Summary = values[2],
                            UnitPrice = double.Parse(values[3]),
                            Quantity = int.Parse(values[4]),

                        };
                        purchaseOrderItem.RecalculateTotal();

                        purchaseOrderItems.Add(purchaseOrderItem);
                    }
                }

                _context.PurchaseOrderItem.AddRange(purchaseOrderItems);
                await _context.SaveChangesAsync();
                ViewData["Message"] = "File uploaded and data saved successfully.";

                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("File", $"An error occurred while processing the file: {ex.Message}");
                return Page();
            }
        }
    }
}