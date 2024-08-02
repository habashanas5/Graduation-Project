using GraduationProject.Applications;
using GraduationProject.Applications.SalesOrderItems;
using GraduationProject.Applications.SalesOrders;
using GraduationProject.Data;
using GraduationProject.Infrastructures.Emails;
using GraduationProject.Models.Entities;
using GraduationProject.Models.Entity;
using GraduationProject.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;

namespace GraduationProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly SalesOrderItemService _salesOrderItemService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public IndexModel
            (ApplicationDbContext context,
            SalesOrderItemService salesOrderItemService,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender)
        {
            _context = context;
            _salesOrderItemService = salesOrderItemService;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public List<ProductGroup> ProductGroups { get; set; }
        public List<Product> products { get; set; }
        public string TopSellingProductsJson { get; set; }
        public string TopPurchasedProductsJson { get; set; }
        public List<Product> TopRatedProducts { get; set; }
        public List<Product> LowestPricedProducts { get; set; }
        public List<SalesOrder> salesOrders { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public List<ApplicationUser> applicationUsers { get; set; } = new List<ApplicationUser>();


        public async Task OnGetAsync()
        {
            ProductGroups = await _context.ProductGroup.ToListAsync();
            products = await _context.Product.ToListAsync();
            TopSellingProductsJson = JsonConvert.SerializeObject(
                            await _context.SalesOrderItem
                                .Include(x => x.Product)
                                .Include(x => x.SalesOrder)
                                .Where(x => x.SalesOrder.OrderStatus >= SalesOrderStatus.Confirmed)
                                .GroupBy(x => x.Product)
                                .Select(g => new
                                {
                                    Product = g.Key,
                                    TotalSales = g.Sum(x => x.Total)
                                })
                                .OrderByDescending(x => x.TotalSales)
                                .Take(3)
                                .ToListAsync()
            );

            TopPurchasedProductsJson = JsonConvert.SerializeObject(
                            await _context.PurchaseOrderItem
                                .Include(x => x.Product)
                                .Include(x => x.PurchaseOrder)
                                .Where(x => x.PurchaseOrder.OrderStatus >= ManufacturingOrderStatus.Confirmed)
                                .GroupBy(x => x.Product)
                                .Select(g => new
                                {
                                    Product = g.Key,
                                    TotalPurchases = g.Sum(x => x.Total)
                                })
                                .OrderByDescending(x => x.TotalPurchases)
                                .Take(3)
                                .ToListAsync()
                        );

            TopRatedProducts = await _context.Product
               .OrderByDescending(x => x.RatingAverage)
               .Take(3)
               .ToListAsync();

            LowestPricedProducts = await _context.Product
               .OrderBy(x => x.UnitPrice)
               .Take(3)
               .ToListAsync();
        }

        public async Task<IActionResult> OnPostAddToCart(int productId, string productName, double price, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var existingItem = await _context.CartItem.FirstOrDefaultAsync(item => item.ProductId == productId && item.UserId == userId);

            if (existingItem != null)
            {
                //existingItem.Quantity++;
                existingItem.Quantity += quantity;
                _context.CartItem.Update(existingItem);
            }
            else
            {
                var newItem = new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity,
                    CreatedDate = DateTime.UtcNow,
                    UserId = userId
                };
                _context.CartItem.Add(newItem);
            }
            await _context.SaveChangesAsync();

            var applicationUser = await _userManager.FindByIdAsync(userId);

            if (applicationUser == null)
            {
                return new JsonResult(new { success = false, message = "User not found" });
            }

            var latitude = applicationUser.Lat;
            var longitude = applicationUser.Lng;

            var deliveryCompanies = await _context.DeliveryCompany.ToListAsync();
            DeliveryCompany nearestDeliveryCompany = null;
            double minDistance = double.MaxValue;

            foreach (var company in deliveryCompanies)
            {
                var distance = DistanceService.CalculateDistance(latitude, longitude, company.Lat, company.Lng);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestDeliveryCompany = company;
                }
            }

            if (nearestDeliveryCompany == null)
            {
                return new JsonResult(new { success = false, message = "No delivery companies found" });
            }

            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.EmailAddress == User.Identity.Name);
            if (customer == null)
            {
                customer = new Customer
                {
                    Name = User.Identity.Name,
                    EmailAddress = User.Identity.Name,
                    CustomerGroupId = applicationUser.CustomerGroupIdUser,
                    CustomerCategoryId = applicationUser.CustomerCategoryIdUser
                };
                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();
            }

            var nearestWarehouseId = applicationUser.NearestWarehouseId; 
            var existingOrder = await _context.SalesOrder.FirstOrDefaultAsync(order => order.UserId == userId && order.OrderStatus == SalesOrderStatus.Draft);
            if (existingOrder == null)
            {
                var newOrder = new SalesOrder
                {
                    Number = Guid.NewGuid().ToString(),
                    OrderDate = DateTime.UtcNow,
                    OrderStatus = SalesOrderStatus.Draft,
                    CustomerId = customer.Id,
                    TaxId = 1,
                    UserId = userId,
                    NearestWarehouseId = nearestWarehouseId,
                    NearestDeliveryId = nearestDeliveryCompany.Id,

                };
                _context.SalesOrder.Add(newOrder);
            }

            await _context.SaveChangesAsync();

            //return RedirectToPage();
            return new JsonResult(new { success = true, message = "Item added to cart successfully" });

        }

        public async Task<IActionResult> OnPostCheckout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartItems = await _context.CartItem
                .Where(item => item.UserId == userId)
                .ToListAsync();

            var salesOrder = await _context.SalesOrder
                .FirstOrDefaultAsync(order => order.UserId == userId && order.OrderStatus == SalesOrderStatus.Draft);

            if (salesOrder == null)
            {
                var customer = await _context.Customer.FirstOrDefaultAsync(c => c.EmailAddress == User.Identity.Name);
                if (customer == null)
                {
                    return new JsonResult(new { success = false, message = "Customer not found" });
                }

                var applicationUser = await _userManager.FindByIdAsync(userId);
                var nearestWarehouseId = applicationUser?.NearestWarehouseId;

                salesOrder = new SalesOrder
                {
                    Number = Guid.NewGuid().ToString(),
                    OrderDate = DateTime.UtcNow,
                    OrderStatus = SalesOrderStatus.Confirmed,
                    CustomerId = customer.Id,
                    TaxId = 1,
                    UserId = userId,
                    NearestWarehouseId = nearestWarehouseId
                };
                _context.SalesOrder.Add(salesOrder);
                await _context.SaveChangesAsync();
            }

            foreach (var cartItem in cartItems)
            {

                var warehouseProduct = await _context.WarehouseProduct
         .FirstOrDefaultAsync(wp => wp.WarehouseId == salesOrder.NearestWarehouseId && wp.ProductId == cartItem.ProductId);

                if (warehouseProduct == null || warehouseProduct.Quantity < cartItem.Quantity)
                {
                    return new JsonResult(new { success = false, message = "Insufficient product quantity in the nearest warehouse" });
                }

                warehouseProduct.Quantity -= (int)cartItem.Quantity;
                _context.WarehouseProduct.Update(warehouseProduct);

                var salesOrderItem = new SalesOrderItem
                {
                    SalesOrderId = salesOrder.Id,
                    ProductId = cartItem.ProductId,
                    Summary = $"Product: {cartItem.ProductName}, Quantity: {cartItem.Quantity}",
                    UnitPrice = cartItem.Price,
                    Quantity = cartItem.Quantity,
                    Total = cartItem.Price * cartItem.Quantity,
                    NearestWarehouseId = salesOrder.NearestWarehouseId,
                };

                _context.SalesOrderItem.Add(salesOrderItem);
                _context.CartItem.Remove(cartItem);
            }

            await _context.SaveChangesAsync();

            var userEmail = User.Identity.Name;
            var adminEmail = "habashanas716@gmail.com";

            await _emailSender.SendEmailAsync(userEmail, "Order Confirmation", "Thank you for your order. We will contact you soon for delivery.");
            await _emailSender.SendEmailAsync(adminEmail, "New Order Checkout", "A new order has been placed.");

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRateProductAsync(int productId, int rating)
        {
            var product = await _context.Product.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            product.rating += 1;
            product.RatingAverage = (double)(((product.RatingAverage * (product.rating - 1)) + rating) / product.rating);

            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            //return RedirectToPage();
            return new JsonResult(new { success = true });

        }
    }
}