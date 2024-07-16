using GraduationProject.Applications.Vendors;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.ApiOData
{
    public class VendorController : ODataController
    {
        private readonly VendorService _vendorService;

        public VendorController(VendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [EnableQuery]
        public IQueryable<FactoriesDto> Get()
        {
            return _vendorService
                .GetAll()
                .Include(x => x.VendorGroup)
                .Include(x => x.VendorCategory)
                .Select(rec => new FactoriesDto
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Number = rec.Number,
                    Description = rec.Description,
                    Street = rec.Street,
                    City = rec.City,
                    State = rec.State,
                    ZipCode = rec.ZipCode,
                    Country = rec.Country,
                    PhoneNumber = rec.PhoneNumber,
                    FaxNumber = rec.FaxNumber,
                    EmailAddress = rec.EmailAddress,
                    Website = rec.Website,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                    VendorGroup = rec.VendorGroup!.Name,
                    VendorCategory = rec.VendorCategory!.Name,
                    Ranking = rec.Ranking,
                });
        }


    }
}
