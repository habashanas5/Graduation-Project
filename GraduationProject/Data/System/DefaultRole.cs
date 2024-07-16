using GraduationProject.AppSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace GraduationProject.Data.System
{
    public static class DefaultRole
    {
        public static async Task GenerateAsync(
            RoleManager<IdentityRole>? roleManager,
            IOptions<ApplicationConfiguration>? appConfig
        )
        {
            if (roleManager != null && appConfig != null)
            {
                await roleManager.CreateAsync(new IdentityRole(appConfig?.Value.RoleAdmin ?? string.Empty));
                await roleManager.CreateAsync(new IdentityRole(appConfig?.Value.RoleCustomerName ?? string.Empty));
                await roleManager.CreateAsync(new IdentityRole(appConfig?.Value.RoleFactoriesName ?? string.Empty));
                await roleManager.CreateAsync(new IdentityRole(appConfig?.Value.RoleWarehouseManager ?? string.Empty));


            }
        }
    }
}
