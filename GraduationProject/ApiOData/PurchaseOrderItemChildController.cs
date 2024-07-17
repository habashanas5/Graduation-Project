using AutoMapper;
using GraduationProject.Applications.PurchaseOrderItems;
using GraduationProject.Applications.PurchaseOrders;
using GraduationProject.DTOS;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.ApiOData
{
    [Route("api/[controller]")]
    public class PurchaseOrderItemChildController : ODataController
    {

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<ManufacturingOrdersItems, ManufacturingOrderItemChildDto>();
                CreateMap<ManufacturingOrderItemChildDto, ManufacturingOrdersItems>();
            }
        }

        private readonly PurchaseOrderService _purchaseOrderService;
        private readonly PurchaseOrderItemService _purchaseOrderItemService;
        private readonly IMapper _mapper;

        public PurchaseOrderItemChildController(
            PurchaseOrderService purchaseOrderService,
            IMapper mapper,
            PurchaseOrderItemService purchaseOrderItemService)
        {
            _mapper = mapper;
            _purchaseOrderService = purchaseOrderService;
            _purchaseOrderItemService = purchaseOrderItemService;
        }

        [EnableQuery]
        public IQueryable<ManufacturingOrderItemChildDto> Get()
        {
            const string HeaderKeyName = "ParentId";
            Request.Headers.TryGetValue(HeaderKeyName, out var headerValue);
            var parentId = int.Parse(headerValue.ToString());

            return _purchaseOrderItemService
                .GetAll()
                .Where(x => x.PurchaseOrderId == parentId)
                .Select(x => _mapper.Map<ManufacturingOrderItemChildDto>(x));
        }


        [EnableQuery]
        [HttpGet("{key}")]
        public SingleResult<ManufacturingOrderItemChildDto> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_purchaseOrderItemService
                .GetAll()
                .Where(x => x.Id == key)
            .Select(x => _mapper.Map<ManufacturingOrderItemChildDto>(x)));
        }



        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] int key, [FromBody] Delta<ManufacturingOrderItemChildDto> delta)
        {
            try
            {
                var purchaseOrderItem = await _purchaseOrderItemService
                    .GetAll()
                    .Where(x => x.Id == key)
                    .FirstOrDefaultAsync();

                if (purchaseOrderItem == null)
                {
                    return NotFound();
                }

                var dto = _mapper.Map<ManufacturingOrderItemChildDto>(purchaseOrderItem);
                delta.Patch(dto);
                var entity = _mapper.Map(dto, purchaseOrderItem);
                await _purchaseOrderItemService.UpdateAsync(entity);

                return Ok(_mapper.Map<ManufacturingOrderItemChildDto>(entity));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ManufacturingOrderItemChildDto purchaseOrderItem)
        {
            try
            {

                const string HeaderKeyName = "ParentId";
                Request.Headers.TryGetValue(HeaderKeyName, out var headerValue);
                var parentId = int.Parse(headerValue.ToString());

                purchaseOrderItem.PurchaseOrderId = parentId;
                var entity = _mapper.Map<ManufacturingOrdersItems>(purchaseOrderItem);
                await _purchaseOrderItemService.AddAsync(entity);

                var dto = _mapper.Map<ManufacturingOrdersItems>(entity);
                return Created("PurchaseOrderItemChild", dto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            try
            {
                var purchaseOrderItem = await _purchaseOrderItemService.GetAll()
                    .Where(x => x.Id == key)
                    .FirstOrDefaultAsync();

                if (purchaseOrderItem == null)
                {
                    return BadRequest();
                }

                await _purchaseOrderItemService.DeleteByIdAsync(purchaseOrderItem.Id);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
