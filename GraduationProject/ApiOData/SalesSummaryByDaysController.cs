using GraduationProject.Applications.CustomerGroups;
using GraduationProject.Applications.Customers;
using GraduationProject.Applications.SalesSummaryByDays;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GraduationProject.ApiOData
{
    public class SalesSummaryByDaysController : ODataController
    {
        private readonly SalesSummaryByDayService _salesSummaryByDayService;

        public SalesSummaryByDaysController (SalesSummaryByDayService salesSummaryByDayService)
        {
            _salesSummaryByDayService = salesSummaryByDayService;
        }
        [EnableQuery]
        public IQueryable<SalesSummaryByDaysDTO> Get()
        {
            return _salesSummaryByDayService
                .GetAll()
                .Select(rec => new SalesSummaryByDaysDTO
                {
                    Id = rec.Id,
                    RowGuid = rec.RowGuid,
                    ProductId = rec.ProductId,
                    ProductName = rec.ProductName,
                    NumberOfProductSold = rec.NumberOfProductSold,
                    Date = rec.Date,
                    NumberOfSales = rec.NumberOfSales,
                    CreatedAtUtc = rec.CreatedAtUtc
                });
        }
    }
}
