using GraduationProject.Applications.VendorGroups;
using GraduationProject.Models.Entities;

namespace GraduationProject.Data.Demo
{
    public static class DemoVendorGroup
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var service = services.GetRequiredService<VendorGroupService>();

            await service.AddAsync(new FactoriesType { Name = "Manufacture" });
            await service.AddAsync(new FactoriesType { Name = "Supplier" });
            await service.AddAsync(new FactoriesType { Name = "Service Provider" });
            await service.AddAsync(new FactoriesType { Name = "Distributor" });
            await service.AddAsync(new FactoriesType { Name = "Freelancer" });
        }
    }
}
