using GraduationProject.Applications.Warehouses;
using GraduationProject.Models.Entity;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace GraduationProject.Data.System
{
    public static class DefaultSystemWarehouse
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var service = services.GetRequiredService<WarehouseService>();
            await service.AddAsync(new Warehouse { Name = "Customer", IsDefault = true });
            await service.AddAsync(new Warehouse { Name = "Vendor", IsDefault = true });
            await service.AddAsync(new Warehouse { Name = "Transfer", IsDefault = true });
            await service.AddAsync(new Warehouse { Name = "Adjustment", IsDefault = true });
            await service.AddAsync(new Warehouse { Name = "StockCount", IsDefault = true });
            await service.AddAsync(new Warehouse { Name = "Scrapping", IsDefault = true });

        }
    }
}