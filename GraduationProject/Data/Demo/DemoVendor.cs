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

            await vendorService.AddAsync(new Factorys
            {
                Name = "Quantum Industries",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Apex Ventures",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Horizon Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Nova Innovations",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Phoenix Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Titan Group",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Zenith Corporation",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Prime Solutions",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Cascade Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Aurora Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Vanguard Industries",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Empyrean Ventures",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Genesis Corporation",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Equinox Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Summit Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Sovereign Solutions",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Spectrum Corporation",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Elysium Enterprises",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Infinity Holdings",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
            await vendorService.AddAsync(new Factorys
            {
                Name = "Momentum Ventures",
                Number = numberSequenceService.GenerateNumber(nameof(Factorys), "", "VND"),
                VendorGroupId = DbInitializer.GetRandomValue(groups, random),
                VendorCategoryId = DbInitializer.GetRandomValue(categories, random),
                City = DbInitializer.GetRandomString(cities, random)
            });
        }
    }
}
