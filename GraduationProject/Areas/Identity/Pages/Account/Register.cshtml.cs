﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using GraduationProject.Applications;
using GraduationProject.Applications.ApplicationUsers;
using GraduationProject.Applications.City;
using GraduationProject.Applications.Companies;
using GraduationProject.AppSettings;
using GraduationProject.Data;
using GraduationProject.Infrastructures.Countries;
using GraduationProject.Models.Entities;
using GraduationProject.Models.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;


namespace GraduationProject.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
       // private readonly RegistrationConfiguration _registrationConfiguration;
        private readonly CompanyService _companyService;
        private readonly ICountryService _countrySevice;
       // private readonly ApplicationUserService _userService;
       // private readonly CityInfoService _cityInfoService;

        public RegisterModel(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
          //  IOptions<RegistrationConfiguration> registrationConfiguration,
            CompanyService companyService,
           // CityInfoService cityInfoService,
            ICountryService countrySevice
           // ApplicationUserService userServic
           )

        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            // _registrationConfiguration = registrationConfiguration.Value;
            _companyService = companyService;
            _countrySevice = countrySevice;
            //_userService = userService;
            // _cityInfoService = cityInfoService;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "User Name")]
            public string UserName { get; set; }
            // [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            // [Display(Name = "First Name")]
            // public string FirstName { get; set; }

            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            // [Display(Name = "Last Name")]
            // public string LastName { get; set; }
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Customer Group")]
            public int CustomerGroupId { get; set; }

            [Display(Name = "Customer Category")]
            public int CustomerCategoryId { get; set; }

            //[Display(Name = "City Info")]
            //public int CityInfoId { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }
            [Display(Name = "City")]
            public string City { get; set; }
            [Display(Name = "State")]
            public string State { get; set; }

            [Display(Name = "Country")]
            public string Country { get; set; }
            [Display(Name = "ZipCode")]
            public string ZipCode { get; set; }

        }

        public List<CustomerGroup> CustomerGroups { get; set; }
        public List<CityInfo> Cities { get; set; }
        public List<CustomerCategory> CustomerCategories { get; set; }
        public ICollection<SelectListItem> Countries { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            CustomerGroups = await _context.CustomerGroup.ToListAsync();
            CustomerCategories = await _context.CustomerCategory.ToListAsync();
            Countries = _countrySevice.GetCountries();
            Cities = await _context.CityInfo.ToListAsync();

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                var defaultCompany = await _companyService.GetDefaultCompanyAsync();
                user.SelectedCompanyId = defaultCompany.Id;
                user.UserName = new MailAddress(Input.Email).User;
                user.Email = Input.Email;
                user.FullName = Input.UserName;
                user.CustomerGroupIdUser = Input.CustomerGroupId;
                user.CustomerCategoryIdUser = Input.CustomerCategoryId;
                user.Address = Input.Address;
                user.City = Input.City;
                user.State = Input.State;
                user.Country = Input.Country;
                user.ZipCode = Input.ZipCode;
                user.PhoneNumber = Input.PhoneNumber;
                //user.CityInfoId = Input.CityInfoId;

                /*var cityInfo = await _context.CityInfo.FindAsync(Input.CityInfoId);
                if (cityInfo != null)
                {
                    user.Lat = cityInfo.Lat;
                    user.Lng = cityInfo.Lng;
                }*/

                //var warehouses = await _context.Warehouse.ToListAsync();

                var (latitude, longitude) = await GetCoordinatesAsync(Input.City, Input.Country);
                user.Lat = (decimal)latitude;
                user.Lng = (decimal)longitude;
                
                var warehouseIds = new List<int> { 1, 3, 4 }; 

                var warehouses = await _context.Warehouse
                    .Where(w => warehouseIds.Contains(w.Id))
                    .ToListAsync();
                Warehouse nearestWarehouse = null;
                double minDistance = double.MaxValue;
                foreach (var warehouse in warehouses)
                {
                    var distance = DistanceService.CalculateDistance(user.Lat, user.Lng, warehouse.Lat, warehouse.Lng);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestWarehouse = warehouse;
                    }
                }

                if (nearestWarehouse != null)
                {
                    user.NearestWarehouseId = nearestWarehouse.Id;
                }

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _userManager.AddToRoleAsync(user, "Customer");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

        static async Task<(double latitude, double longitude)> GetCoordinatesAsync(string city, string country)
        {
            string url = $"https://nominatim.openstreetmap.org/search?q={city},{country}&format=json";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "MyApp/1.0");

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JArray jsonArray = JArray.Parse(json);
                        if (jsonArray.Count > 0)
                        {
                            double latitude = Convert.ToDouble(jsonArray[0]["lat"]);
                            double longitude = Convert.ToDouble(jsonArray[0]["lon"]);
                            return (latitude, longitude);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: Received response status code {response.StatusCode} for {city}, {country}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred for {city}, {country}: {ex.Message}");
                }
            }
            return (0, 0);
        }
    }
}