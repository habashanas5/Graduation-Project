using GraduationProject.Applications.VendorCategories;
using GraduationProject.Models.Entities;

namespace GraduationProject.Data.Demo
{
    public static class DemoVendorCategory
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var service = services.GetRequiredService<VendorCategoryService>();

            await service.AddAsync(new FactoriesClassification { Name = "Large" });
            await service.AddAsync(new FactoriesClassification { Name = "Medium" });
            await service.AddAsync(new FactoriesClassification { Name = "Small" });
            await service.AddAsync(new FactoriesClassification { Name = "Specialty" });
            await service.AddAsync(new FactoriesClassification { Name = "Local" });
            await service.AddAsync(new FactoriesClassification { Name = "Global" });
        }
    }
}
