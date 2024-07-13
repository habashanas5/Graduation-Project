using GraduationProject.Applications.AdjustmentMinuss;
using GraduationProject.Applications.AdjustmentPluss;
using GraduationProject.Applications.ApplicationUsers;
using GraduationProject.Applications.Companies;
using GraduationProject.Applications.CustomerCategories;
using GraduationProject.Applications.CustomerContacts;
using GraduationProject.Applications.CustomerGroups;
using GraduationProject.Applications.Customers;
using GraduationProject.Applications.DeliveryOrders;
using GraduationProject.Applications.GoodsReceives;
using GraduationProject.Applications.InventoryTransactions;
using GraduationProject.Applications.LogAnalytics;
using GraduationProject.Applications.LogErrors;
using GraduationProject.Applications.LogSessions;
using GraduationProject.Applications.NumberSequences;
using GraduationProject.Applications.ProductGroups;
using GraduationProject.Applications.Products;
using GraduationProject.Applications.PurchaseOrderItems;
using GraduationProject.Applications.PurchaseOrders;
using GraduationProject.Applications.PurchaseReturns;
using GraduationProject.Applications.SalesOrderItems;
using GraduationProject.Applications.SalesOrders;
using GraduationProject.Applications.SalesReturns;
using GraduationProject.Applications.Scrappings;
using GraduationProject.Applications.StockCounts;
using GraduationProject.Applications.Taxes;
using GraduationProject.Applications.TransferIns;
using GraduationProject.Applications.TransferOuts;
using GraduationProject.Applications.UnitMeasures;
using GraduationProject.Applications.VendorCategories;
using GraduationProject.Applications.VendorContacts;
using GraduationProject.Applications.VendorGroups;
using GraduationProject.Applications.Vendors;
using GraduationProject.Applications.Warehouses;
using GraduationProject.Infrastructures.Countries;
using GraduationProject.Infrastructures.Currencies;
using GraduationProject.Infrastructures.Docs;
using GraduationProject.Infrastructures.Emails;
using GraduationProject.Infrastructures.Images;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Infrastructures.TimeZones;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GraduationProject
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IEmailSender, SMTPEmailService>();
            services.AddScoped<IFileImageService, FileImageService>();
            services.AddScoped<IFileDocumentService, FileDocumentService>();
            services.AddScoped<ITimeZoneService, TimeZoneService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IAuditColumnTransformer, AuditColumnTransformer>();
            services.AddScoped<CompanyService>();
            services.AddScoped<ApplicationUserService>();
            services.AddScoped<NumberSequenceService>();
            services.AddScoped<LogErrorService>();
            services.AddScoped<LogSessionService>();
            services.AddScoped<LogAnalyticService>();
            services.AddScoped<CustomerGroupService>();
            services.AddScoped<CustomerCategoryService>();
            services.AddScoped<VendorGroupService>();
            services.AddScoped<VendorCategoryService>();
            services.AddScoped<WarehouseService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<VendorService>();
            services.AddScoped<UnitMeasureService>();
            services.AddScoped<ProductGroupService>();
            services.AddScoped<ProductService>();
            services.AddScoped<CustomerContactService>();
            services.AddScoped<VendorContactService>();
            services.AddScoped<TaxService>();
            services.AddScoped<SalesOrderService>();
            services.AddScoped<SalesOrderItemService>();
            services.AddScoped<PurchaseOrderService>();
            services.AddScoped<PurchaseOrderItemService>();
            services.AddScoped<InventoryTransactionService>();
            services.AddScoped<DeliveryOrderService>();
            services.AddScoped<GoodsReceiveService>();
            services.AddScoped<SalesReturnService>();
            services.AddScoped<PurchaseReturnService>();
            services.AddScoped<TransferInService>();
            services.AddScoped<TransferOutService>();
            services.AddScoped<StockCountService>();
            services.AddScoped<AdjustmentMinusService>();
            services.AddScoped<AdjustmentPlusService>();
            services.AddScoped<ScrappingService>();
            services.AddScoped<DeliveryOrderService>();


            return services;
        }
    }
}
