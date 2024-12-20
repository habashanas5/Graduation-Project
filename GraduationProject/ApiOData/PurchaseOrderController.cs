﻿using GraduationProject.Applications.PurchaseOrders;
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

    public class PurchaseOrderController : ODataController
    {
        private readonly PurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(PurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [EnableQuery]
        public IQueryable<ManufacturingOrderDto> Get()
        {
            return _purchaseOrderService
                .GetAll()
                .Include(x => x.Vendor)
                .Include(x => x.Tax)
                .Select(rec => new ManufacturingOrderDto
                {
                    Id = rec.Id,
                    Number = rec.Number,
                    OrderDate = rec.OrderDate,
                    Status = rec.OrderStatus,
                    Description = rec.Description,
                    Factory = rec.Vendor!.Name,
                    Tax = rec.Tax!.Name,
                    BeforeTaxAmount = rec.BeforeTaxAmount,
                    TaxAmount = rec.TaxAmount,
                    AfterTaxAmount = rec.AfterTaxAmount,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                });
        }



        [EnableQuery]
        [HttpGet("{key}")]
        public SingleResult<ManufacturingOrderDto> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_purchaseOrderService
                .GetAll()
                .Where(x => x.Id == key)
                .Select(rec => new ManufacturingOrderDto
                {
                    Id = rec.Id,
                    Number = rec.Number,
                    OrderDate = rec.OrderDate,
                    Status = rec.OrderStatus,
                    Description = rec.Description,
                    Factory = rec.Vendor!.Name,
                    Tax = rec.Tax!.Name,
                    BeforeTaxAmount = rec.BeforeTaxAmount,
                    TaxAmount = rec.TaxAmount,
                    AfterTaxAmount = rec.AfterTaxAmount,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                })
            );
        }


    }
}
