<<<<<<< HEAD
﻿using GraduationProject.Applications.Warehouses;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GraduationProject.ApiOData
{
    public class WarehouseController : ODataController
    {
        private readonly WarehouseService _warehouseService;

        public WarehouseController(WarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [EnableQuery]
        public IQueryable<WarehouseDto> Get()
        {
            return _warehouseService
                .GetAll()
                .Select(rec => new WarehouseDto
                {
                    Id = rec.Id,
                    RowGuid = rec.RowGuid,
                    Name = rec.Name,
                    IsDefault = rec.IsDefault,
                    Description = rec.Description,
                    CreatedAtUtc = rec.CreatedAtUtc,
                    PhoneNumber = rec.PhoneNumber,
                    Address = rec.Address,
                    City = rec.City,
                    State = rec.State,
                    PostalCode = rec.PostalCode

                });
        }


    }
}
=======
﻿using GraduationProject.Applications.Warehouses;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GraduationProject.ApiOData
{
    public class WarehouseController : ODataController
    {
        private readonly WarehouseService _warehouseService;

        public WarehouseController(WarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [EnableQuery]
        public IQueryable<WarehouseDto> Get()
        {
            return _warehouseService
                .GetAll()
                .Select(rec => new WarehouseDto
                {
                    Id = rec.Id,
                    RowGuid = rec.RowGuid,
                    Name = rec.Name,
                    IsDefault = rec.IsDefault,
                    Description = rec.Description,
                    CreatedAtUtc = rec.CreatedAtUtc,
                    PhoneNumber = rec.PhoneNumber,
                    Address = rec.Address,
                    City = rec.City,
                    State = rec.State,
                    PostalCode = rec.PostalCode

                });
        }


    }
}
>>>>>>> c44e5491702d5f390efd342c62b729fc7935292e
