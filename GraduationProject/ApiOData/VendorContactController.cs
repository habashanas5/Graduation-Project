using GraduationProject.Applications.VendorContacts;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.ApiOData
{
    public class VendorContactController : ODataController
    {
        private readonly VendorContactService _vendorContactService;

        public VendorContactController(VendorContactService vendorContactService)
        {
            _vendorContactService = vendorContactService;
        }

        [EnableQuery]
        public IQueryable<FactoriesContactsDto> Get()
        {
            return _vendorContactService
                .GetAll()
                .Include(x => x.Factory)
                .Select(rec => new FactoriesContactsDto
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Number = rec.Number,
                    JobTitle = rec.JobTitle,
                    Description = rec.Description,
                    PhoneNumber = rec.PhoneNumber,
                    EmailAddress = rec.EmailAddress,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                    Factory = rec.Factory!.Name,
                });
        }


    }
}
