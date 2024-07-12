<<<<<<< HEAD
﻿using GraduationProject.Applications.DeliveryOrders;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.ApiOData
{
    public class DeliveryOrderController : ODataController
    {
        private readonly DeliveryOrderService _deliveryOrderService;

        public DeliveryOrderController(DeliveryOrderService deliveryOrderService)
        {
            _deliveryOrderService = deliveryOrderService;
        }

        [EnableQuery]
        public IQueryable<DeliveryOrderDto> Get()
        {
            return _deliveryOrderService
                .GetAll()
                .Include(x => x.SalesOrder)
                    .ThenInclude(x => x!.Customer)
                .Select(rec => new DeliveryOrderDto
                {
                    Id = rec.Id,
                    Number = rec.Number,
                    DeliveryDate = rec.DeliveryDate,
                    Status = rec.Status,
                    SalesOrder = rec.SalesOrder!.Number,
                    OrderDate = rec.SalesOrder!.OrderDate,
                    Customer = rec.SalesOrder!.Customer!.Name,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                });
        }




    }
}
=======
﻿using GraduationProject.Applications.DeliveryOrders;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.ApiOData
{
    public class DeliveryOrderController : ODataController
    {
        private readonly DeliveryOrderService _deliveryOrderService;

        public DeliveryOrderController(DeliveryOrderService deliveryOrderService)
        {
            _deliveryOrderService = deliveryOrderService;
        }

        [EnableQuery]
        public IQueryable<DeliveryOrderDto> Get()
        {
            return _deliveryOrderService
                .GetAll()
                .Include(x => x.SalesOrder)
                    .ThenInclude(x => x!.Customer)
                .Select(rec => new DeliveryOrderDto
                {
                    Id = rec.Id,
                    Number = rec.Number,
                    DeliveryDate = rec.DeliveryDate,
                    Status = rec.Status,
                    SalesOrder = rec.SalesOrder!.Number,
                    OrderDate = rec.SalesOrder!.OrderDate,
                    Customer = rec.SalesOrder!.Customer!.Name,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                });
        }




    }
}
>>>>>>> c44e5491702d5f390efd342c62b729fc7935292e
