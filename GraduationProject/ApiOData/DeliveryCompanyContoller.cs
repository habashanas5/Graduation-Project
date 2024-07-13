using GraduationProject.Applications.DeliveryCompanys;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.ApiOData
{
    public class DeliveryCompanyController : ODataController
    {
        private readonly DeliveryCompanyService _deliveryCompanyService;

        public DeliveryCompanyController(DeliveryCompanyService deliveryCompanyService)
        {
            _deliveryCompanyService = deliveryCompanyService;
        }

        [EnableQuery]
        public IQueryable<DeliveryCompanyDto> Get()
        {
            return _deliveryCompanyService
                .GetAll()
                .Select(dc => new DeliveryCompanyDto
                {
                    Id = dc.Id,
                    Name = dc.Name,
                    ContactNumber = dc.ContactNumber,
                    Email = dc.Email,
                    Address = dc.Address,
                    RowGuid = dc.RowGuid,
                    CreatedAtUtc = dc.CreatedAtUtc
                });
        }
    }
}
