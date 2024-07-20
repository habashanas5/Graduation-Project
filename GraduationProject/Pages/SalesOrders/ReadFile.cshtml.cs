using GraduationProject.Data;
using GraduationProject.Infrastructures.Extensions;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using GraduationProject.Models.Enums;


namespace GraduationProject.Pages.SalesOrders
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

            var salesOrderItems = new List<SalesOrderItem>();
            var salesOrderDate = DateTime.UtcNow;
            var orderNumber = GenerateOrderNumber();

            var salesOrder = new SalesOrder
            {
                Number = orderNumber,
                OrderDate = salesOrderDate,
                OrderStatus = SalesOrderStatus.Confirmed,
                Description = "Order from file upload",
                CustomerId = 1, 
                TaxId = 1, 
                BeforeTaxAmount = 0,
                TaxAmount = 0,
                AfterTaxAmount = 0,
                IsNotDeleted = true,
            };

            try
            {
                using (var stream = new StreamReader(File.OpenReadStream()))
                {
                    while (!stream.EndOfStream)
                    {
                        var line = await stream.ReadLineAsync();
                        var values = line.Split(',');

                        var salesOrderItem = new SalesOrderItem
                        {
                            SalesOrderId = int.Parse(values[0]),
                            ProductId = int.Parse(values[1]),
                            Summary = values[2],
                            UnitPrice = double.Parse(values[3]),
                            Quantity = int.Parse(values[4]),
                            WarehouseNumber = 1
                        };
                        salesOrderItem.RecalculateTotal();

                        salesOrderItems.Add(salesOrderItem);
                    }
                }
                salesOrder.BeforeTaxAmount = salesOrderItems.Sum(item => item.Total);
                salesOrder.TaxAmount = salesOrder.BeforeTaxAmount * 0.1; 
                salesOrder.AfterTaxAmount = salesOrder.BeforeTaxAmount + salesOrder.TaxAmount;
                _context.SalesOrder.Add(salesOrder);

                _context.SalesOrderItem.AddRange(salesOrderItems);
                await _context.SaveChangesAsync();

                var summaryUpdates = salesOrderItems.GroupBy(item => new
                {
                    item.ProductId,
                    Date = salesOrder.OrderDate.HasValue ? salesOrder.OrderDate.Value.Date : DateTime.MinValue
                })
                      .Select(group => new
                      {
                          group.Key.ProductId,
                          group.Key.Date,
                          NumberOfSales = group.Count(),
                          NumberOfProductSold = group.Sum(item => (int)item.Quantity)
                      });

                foreach (var update in summaryUpdates)
                {
                    var summaryRecord = await _context.SalesSummaryByDay
                        .FirstOrDefaultAsync(s => s.Date == update.Date && s.ProductId == update.ProductId);

                    var product = await _context.Product
                        .FirstOrDefaultAsync(p => p.Id == update.ProductId);
                    if (product == null)
                    {
                        ModelState.AddModelError("Product", $"Product with ID {update.ProductId} not found.");
                        return Page(); 
                    }

                    if (summaryRecord != null)
                    {
                        summaryRecord.NumberOfSales += update.NumberOfSales;
                        summaryRecord.NumberOfProductSold += update.NumberOfProductSold;
                    }
                    else
                    {
                        _context.SalesSummaryByDay.Add(new SalesSummaryByDay
                        {
                            Date = update.Date,
                            ProductId = update.ProductId,
                            Products = product,
                            ProductName = product.Name,
                            NumberOfSales = update.NumberOfSales,
                            NumberOfProductSold = update.NumberOfProductSold
                        });
                    }
                }
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

        private string GenerateOrderNumber()
        {
            return DateTime.UtcNow.Ticks.ToString();
        }
    }
}