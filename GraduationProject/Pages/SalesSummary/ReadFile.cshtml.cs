using GraduationProject.Data;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.SalesSummary
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
            var salesSummaries = new List<SalesSummaryByDay>();

            try
            {
                using (var stream = new StreamReader(File.OpenReadStream()))
                {
                    while (!stream.EndOfStream)
                    {
                        var line = await stream.ReadLineAsync();
                        var values = line.Split(',');

                        var salesSummary = new SalesSummaryByDay
                        {
                            Date = DateTime.Parse(values[0]),
                            ProductId = int.Parse(values[1]),
                            ProductName = values[2],
                            NumberOfSales = int.Parse(values[3]),
                            NumberOfProductSold = int.Parse(values[4])
                        };

                        salesSummaries.Add(salesSummary);
                    }
                }

                _context.SalesSummaryByDay.AddRange(salesSummaries);
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