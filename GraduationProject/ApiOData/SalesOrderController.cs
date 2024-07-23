﻿using GraduationProject.Applications.SalesOrders;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.ApiOData
{
    [Route("api/[controller]")]
    public class SalesOrderController : ODataController
    {
        private readonly SalesOrderService _salesOrderService;

        public SalesOrderController(SalesOrderService salesOrderService)
        {
            _salesOrderService = salesOrderService;
        }

        [EnableQuery]
        public IQueryable<SalesOrderDto> Get()
        {
            return _salesOrderService
                .GetAll()
                .Include(x => x.Customer)
                .Include(x => x.Tax)
                .Include(x => x.NearestWarehouse)
                .Select(rec => new SalesOrderDto
                {
                    Id = rec.Id,
                    Number = rec.Number,
                    OrderDate = rec.OrderDate,
                    Status = rec.OrderStatus,
                    Description = rec.Description,
                    Customer = rec.Customer!.Name,
                    Tax = rec.Tax!.Name,
                    BeforeTaxAmount = rec.BeforeTaxAmount,
                    TaxAmount = rec.TaxAmount,
                    AfterTaxAmount = rec.AfterTaxAmount,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                    NearestWarehouseName = rec.NearestWarehouse != null ? rec.NearestWarehouse.Name : null
                });
        }



        [EnableQuery]
        [HttpGet("{key}")]
        public SingleResult<SalesOrderDto> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_salesOrderService
                .GetAll()
                .Where(x => x.Id == key)
                .Include(x => x.NearestWarehouse) 
                .Select(rec => new SalesOrderDto
                {
                    Id = rec.Id,
                    Number = rec.Number,
                    OrderDate = rec.OrderDate,
                    Status = rec.OrderStatus,
                    Description = rec.Description,
                    Customer = rec.Customer!.Name,
                    Tax = rec.Tax!.Name,
                    BeforeTaxAmount = rec.BeforeTaxAmount,
                    TaxAmount = rec.TaxAmount,
                    AfterTaxAmount = rec.AfterTaxAmount,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                    NearestWarehouseId = rec.NearestWarehouseId,
                    NearestWarehouseName = rec.NearestWarehouse != null ? rec.NearestWarehouse.Name : null

                })
            );
        }


    }
}
