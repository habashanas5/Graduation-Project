﻿using GraduationProject.Applications.PurchaseReturns;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.ApiOData
{
    public class PurchaseReturnController : ODataController
    {
        private readonly PurchaseReturnService _purchaseReturnService;

        public PurchaseReturnController(PurchaseReturnService purchaseReturnService)
        {
            _purchaseReturnService = purchaseReturnService;
        }

        [EnableQuery]
        public IQueryable<ManufacturingReturnDto> Get()
        {
            return _purchaseReturnService
                .GetAll()
                .Include(x => x.GoodsReceive)
                    .ThenInclude(x => x!.PurchaseOrder)
                        .ThenInclude(x => x!.Vendor)
                .Select(rec => new ManufacturingReturnDto
                {
                    Id = rec.Id,
                    Number = rec.Number,
                    ReturnDate = rec.ReturnDate,
                    Status = rec.Status,
                    GoodsReceive = rec.GoodsReceive!.Number,
                    ReceiveDate = rec.GoodsReceive!.ReceiveDate,
                    Factory = rec.GoodsReceive!.PurchaseOrder!.Vendor!.Name,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                });
        }




    }
}
