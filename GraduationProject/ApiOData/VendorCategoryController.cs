using GraduationProject.Applications.VendorCategories;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GraduationProject.ApiOData
{
    public class VendorCategoryController : ODataController
    {
        private readonly VendorCategoryService _vendorCategoryService;

        public VendorCategoryController(VendorCategoryService vendorCategoryService)
        {
            _vendorCategoryService = vendorCategoryService;
        }

        [EnableQuery]
        public IQueryable<FactoriesClassificationDto> Get()
        {
            return _vendorCategoryService
                .GetAll()
                .Select(rec => new FactoriesClassificationDto
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
