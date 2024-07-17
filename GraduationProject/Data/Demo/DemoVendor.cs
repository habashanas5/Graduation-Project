using GraduationProject.Applications.NumberSequences;
using GraduationProject.Applications.VendorCategories;
using GraduationProject.Applications.VendorGroups;
using GraduationProject.Applications.Vendors;
using GraduationProject.Models.Entities;

namespace GraduationProject.Data.Demo
{
    public static class DemoVendor
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var vendorService = services.GetRequiredService<VendorService>();
            var numberSequenceService = services.GetRequiredService<NumberSequenceService>();
            var vendorGroupService = services.GetRequiredService<VendorGroupService>();
            var vendorCategoryService = services.GetRequiredService<VendorCategoryService>();

            var groups = vendorGroupService.GetAll().Select(x => x.Id).ToArray();
            var categories = vendorCategoryService.GetAll().Select(x => x.Id).ToArray();
            var cities = new string[] { "New York", "Los Angeles", "San Francisco", "Chicago" };

            Random random = new Random();

            await vendorService.AddAsync(new Factory
            {
                Name = "Quantum Industries",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Apex Ventures",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Horizon Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Nova Innovations",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Phoenix Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Titan Group",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Zenith Corporation",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Prime Solutions",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Cascade Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Aurora Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Vanguard Industries",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Empyrean Ventures",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Genesis Corporation",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Equinox Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Summit Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Sovereign Solutions",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Spectrum Corporation",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Elysium Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Infinity Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factory
            {
                Name = "Momentum Ventures",
                Number = numberSequenceService.GenerateNumber(nameof(Factory), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
        }
    }
}
