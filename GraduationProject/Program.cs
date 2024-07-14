using DeviceDetectorNET.Parser.Device;
using GraduationProject;
using GraduationProject.Applications.ApplicationUsers;
using GraduationProject.Applications.Companies;
using GraduationProject.Applications.DeliveryCompanys;
using GraduationProject.AppSettings;
using GraduationProject.Data;
using GraduationProject.Infrastructures.Emails;
using GraduationProject.Infrastructures.Images;
using GraduationProject.Infrastructures.Middlewares;
using GraduationProject.Infrastructures.ODatas;
using GraduationProject.Infrastructures.Pdfs;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .Configure<IdentitySettings>(builder.Configuration.GetSection(IdentitySettings.IdentitySettingsName));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{ 
        var identitySettings = builder.Configuration.GetSection(IdentitySettings.IdentitySettingsName).Get<IdentitySettings>();
    if (identitySettings != null)
    {
        options.SignIn.RequireConfirmedAccount = identitySettings.RequireConfirmedAccount;
        options.Lockout.DefaultLockoutTimeSpan = identitySettings.DefaultLockoutTimeSpan;
        options.Lockout.MaxFailedAccessAttempts = identitySettings.MaxFailedAccessAttempts;
    }
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddRoles<IdentityRole>()
    .AddDefaultTokenProviders();

builder.Services
    .ConfigureApplicationCookie(options =>
    {
        var appConfig = builder.Configuration.GetSection("ApplicationConfiguration").Get<ApplicationConfiguration>();
        if (appConfig != null)
        {
            options.LoginPath = appConfig.LoginPage;
            options.LogoutPath = appConfig.LogoutPage;
            options.AccessDeniedPath = appConfig.AccessDeniedPage;
        }
    });
builder.Services.AddScoped<IFileImageService, FileImageService>();

builder.Services.AddScoped<IAuditColumnTransformer, AuditColumnTransformer>();

builder.Services.AddScoped<CompanyService>();

builder.Services.AddScoped<IDeliveryCompanyService, DeliveryCompanyService>();

builder.Services.AddScoped<DeliveryCompanyService>();

builder.Services.AddScoped<ApplicationUserService>();

builder.Services.AddTransient<IEmailSender, SMTPEmailService>();

builder.Services.Configure<SmtpConfiguration>(builder.Configuration.GetSection("SmtpConfiguration"));

builder.Services.Configure<RegistrationConfiguration>(builder.Configuration.GetSection("RegistrationConfiguration"));

builder.Services.Configure<ApplicationConfiguration>(builder.Configuration.GetSection("ApplicationConfiguration"));

builder.Services.AddRazorPages();

builder.Services.AddAllCustomServices();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

builder.Services.AddSingleton<IPdfService, PdfService>();

builder.Services.AddCustomOData();

builder.Services.AddSession();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var appConfig = services.GetRequiredService<IOptions<ApplicationConfiguration>>();
    if (appConfig.Value.IsDevelopment)
    {
        context.Database.EnsureCreated();
    }
    await DbInitializer.InitializeAsync(services);
}
app.UseStaticFiles();

app.UseSession();

app.UseMiddleware<LogAnalyticMiddleware>();

app.UseMiddleware<GlobalErrorHandlingMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();

