using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Query.Validator;

namespace GraduationProject.Infrastructures.ODatas
{
    public static class ODataServiceExtensions
    {
        public static void AddCustomOData(this IServiceCollection services)
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<LogAnalyticDto>("LogAnalytic");
            builder.EntitySet<LogErrorDto>("LogError");
            builder.EntitySet<LogSessionDto>("LogSession");
            builder.EntitySet<NumberSequenceDto>("NumberSequence");
            builder.EntitySet<ApplicationUserDto>("ApplicationUser");
            builder.EntitySet<UserProfileDto>("UserProfile");
            builder.EntitySet<CompanyDto>("Company");
            builder.EntitySet<CustomerGroupDto>("CustomerGroup");
            builder.EntitySet<CustomerCategoryDto>("CustomerCategory");
            builder.EntitySet<FactoriesTypeDto>("VendorGroup");
            builder.EntitySet<FactoriesClassificationDto>("VendorCategory");
            builder.EntitySet<WarehouseDto>("Warehouse");
            builder.EntitySet<CustomerDto>("Customer");
            builder.EntitySet<FactoriesDto>("Vendor");
            builder.EntitySet<UnitMeasureDto>("UnitMeasure");
            builder.EntitySet<ProductGroupDto>("ProductGroup");
            builder.EntitySet<ProductDto>("Product");
            builder.EntitySet<CustomerContactDto>("CustomerContact");
            builder.EntitySet<CustomerContactChildDto>("CustomerContactChild");
            builder.EntitySet<FactoriesContactsDto>("VendorContact");
            builder.EntitySet<FactoriesContactChildDto>("VendorContactChild");
            builder.EntitySet<TaxDto>("Tax");
            builder.EntitySet<SalesOrderDto>("SalesOrder");
            builder.EntitySet<SalesOrderItemChildDto>("SalesOrderItemChild");
            builder.EntitySet<SalesOrderItemDto>("SalesOrderItem");
            builder.EntitySet<ManufacturingOrderDto>("PurchaseOrder");
            builder.EntitySet<ManufacturingOrderItemChildDto>("PurchaseOrderItemChild");
            builder.EntitySet<ManufacturingOrderItemDto>("PurchaseOrderItem");
            builder.EntitySet<InvenTransDto>("InvenTrans");
            builder.EntitySet<InvenStockDto>("InvenStock");
            builder.EntitySet<DeliveryOrderDto>("DeliveryOrder");
            builder.EntitySet<SalesReturnDto>("SalesReturn");
            builder.EntitySet<GoodsReceiveDto>("GoodsReceive");
            builder.EntitySet<PurchaseReturnDto>("PurchaseReturn");
            builder.EntitySet<TransferOutDto>("TransferOut");
            builder.EntitySet<TransferInDto>("TransferIn");
            builder.EntitySet<PositiveAdjustmentDto>("PositiveAdjustment");
            builder.EntitySet<NegativeAdjustmentDto>("NegativeAdjustment");
            builder.EntitySet<ScrappingDto>("Scrapping");
            builder.EntitySet<StockCountDto>("StockCount");
            builder.EntitySet<DeliveryOrderItemChildDto>("DeliveryOrderItemChild");
            builder.EntitySet<GoodsReceiveItemChildDto>("GoodsReceiveItemChild");
            builder.EntitySet<SalesReturnItemChildDto>("SalesReturnItemChild");
            builder.EntitySet<PurchaseReturnItemChildDto>("PurchaseReturnItemChild");
            builder.EntitySet<TransferOutItemChildDto>("TransferOutItemChild");
            builder.EntitySet<TransferInItemChildDto>("TransferInItemChild");
            builder.EntitySet<AdjustmentPlusItemChildDto>("AdjustmentPlusItemChild");
            builder.EntitySet<AdjustmentMinusItemChildDto>("AdjustmentMinusItemChild");
            builder.EntitySet<ScrappingItemChildDto>("ScrappingItemChild");
            builder.EntitySet<StockCountItemChildDto>("StockCountItemChild");

            services.AddControllers()
                .AddOData(options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null)
                .AddRouteComponents("odata", builder.GetEdmModel(), odataServices =>
                {
                    odataServices.AddSingleton<IODataQueryValidator, SFODataQueryValidator>();
                }));
        }
    }
}