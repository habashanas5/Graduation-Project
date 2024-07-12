using GraduationProject.Applications.Warehouses;
using GraduationProject.Models.Entity;

namespace GraduationProject.Data.Demo
{
    public static class DemoWarehouse
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var service = services.GetRequiredService<WarehouseService>();

            await service.AddAsync(new Warehouse { Name = "New York" });
            await service.AddAsync(new Warehouse { Name = "San Francisco" });
            await service.AddAsync(new Warehouse { Name = "Chicago" });
            await service.AddAsync(new Warehouse { Name = "Los Angeles" });
        }
    }
}
