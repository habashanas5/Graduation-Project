using GraduationProject.Applications.City;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GraduationProject.ApiOData
{
    public class CityInfoContoller : ODataController
    {
        private readonly CityInfoService _cityInfoService;

        public CityInfoContoller (CityInfoService cityInfoService)
        {
            _cityInfoService = cityInfoService;
        }

        [EnableQuery]
        public IQueryable<CityInfoDTO> Get()
        {
            return _cityInfoService
                .GetAll()
                .Select(rec => new CityInfoDTO
                {
                 Id = rec.Id,
                 RowGuid = rec.RowGuid,
                 CreatedAtUtc = rec.CreatedAtUtc,
                 CityName = rec.CityName,
                 Lat = rec.Lat,
                 Lng = rec.Lng,
                 Country = rec.Country,
                 Population = rec.Population,
                });
        }
    }
}
