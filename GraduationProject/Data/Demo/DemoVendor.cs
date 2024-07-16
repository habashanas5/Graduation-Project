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

            await vendorService.AddAsync(new Factories
            {
                Name = "Quantum Industries",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Apex Ventures",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Horizon Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Nova Innovations",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Phoenix Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Titan Group",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Zenith Corporation",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Prime Solutions",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Cascade Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Aurora Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Vanguard Industries",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Empyrean Ventures",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Genesis Corporation",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Equinox Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Summit Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Sovereign Solutions",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Spectrum Corporation",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Elysium Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Infinity Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factories
            {
                Name = "Momentum Ventures",
                Number = numberSequenceService.GenerateNumber(nameof(Factories), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
        }
    }
}
