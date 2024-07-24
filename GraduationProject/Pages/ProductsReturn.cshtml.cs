using DeviceDetectorNET.Class;
using GraduationProject.Applications.InventoryTransactions;
using GraduationProject.Data;
using GraduationProject.Models.Entities;
using GraduationProject.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Pages
{
    public class Products_ReturnModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly InventoryTransactionService _InventoryTransactionService;

        public Products_ReturnModel(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            InventoryTransactionService InventoryTransactionService,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager; 
            _emailSender = emailSender;
            _InventoryTransactionService = InventoryTransactionService;

        }

        [BindProperty]
        public SalesReturnInputModel SalesReturn { get; set; } = new SalesReturnInputModel();

        public List<Product> Products { get; set; } = new List<Product>();
        //public List<DeliveryOrder> DeliveryOrders { get; set; } = new List<DeliveryOrder>();

        public async Task OnGetAsync()
        {
            Products = await _context.Product.ToListAsync();
           // DeliveryOrders = await _context.DeliveryOrder.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);


            var salesReturn = new SalesReturn
            {
                ReturnDate = SalesReturn.ReturnDate,
                Status = SalesReturnStatus.Pending,
                Description = SalesReturn.Description,
                DeliveryOrderId = 1,
                Products = new List<SalesReturnProduct>(),
                UserId = user.Id,
                User = user,
                Number = Guid.NewGuid().ToString()
            };

            foreach (var product in SalesReturn.Products)
            {
                salesReturn.Products.Add(new SalesReturnProduct
                {
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                    Reason = product.Reason
                });

                var nearestWarehouseId = user.NearestWarehouseId;
                if (nearestWarehouseId.HasValue)
                {
                    // Get the warehouse product
                    var warehouseProduct = await _InventoryTransactionService.GetWarehouseProductAsync(nearestWarehouseId.Value, product.ProductId);

                    if (warehouseProduct != null)
                    {
                        warehouseProduct.Quantity += product.Quantity; 
                        await _InventoryTransactionService.UpdateWarehouseProductAsync(warehouseProduct);
                    }
                }
            }


            _context.SalesReturn.Add(salesReturn);
            var adminEmail = "habashanas716@gmail.com";
            await _emailSender.SendEmailAsync(adminEmail, "Products Return", "A new product return has been placed.");

            await _context.SaveChangesAsync();

            return RedirectToPage("/Success");
        }

        public class SalesReturnInputModel
        {
            public DateTime? ReturnDate { get; set; }
            public List<ProductInputModel> Products { get; set; } = new List<ProductInputModel>();
            public string Description { get; set; }
            public int DeliveryOrderId { get; set; }
            public string? Number { get; set; }
        }

        public class ProductInputModel
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public string Reason { get; set; }
        }
    }
}
