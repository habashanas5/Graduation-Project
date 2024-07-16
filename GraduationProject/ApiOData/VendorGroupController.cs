using GraduationProject.Applications.VendorGroups;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GraduationProject.ApiOData
{
    public class VendorGroupController : ODataController
    {
        private readonly VendorGroupService _vendorGroupService;

        public VendorGroupController(VendorGroupService vendorGroupService)
        {
            _vendorGroupService = vendorGroupService;
        }

        [EnableQuery]
        public IQueryable<FactoriesTypeDto> Get()
        {
            return _vendorGroupService
                .GetAll()
                .Select(rec => new FactoriesTypeDto
                {
                    Id = rec.Id,
                    RowGuid = rec.RowGuid,
                    Name = rec.Name,
                    Description = rec.Description,
                    CreatedAtUtc = rec.CreatedAtUtc
                });
        }


    }
}
