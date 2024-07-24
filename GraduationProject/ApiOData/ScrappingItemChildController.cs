using AutoMapper;
using GraduationProject.Applications.InventoryTransactions;
using GraduationProject.Applications.NumberSequences;
using GraduationProject.Applications.Scrappings;
using GraduationProject.DTOS;
using GraduationProject.Models.Entities;
using GraduationProject.Models.Enums;
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
    public class ScrappingItemChildController : ODataController
    {

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<InventoryTransaction, ScrappingItemChildDto>();
                CreateMap<ScrappingItemChildDto, InventoryTransaction>();
            }
        }

        private readonly NumberSequenceService _numberSequenceService;
        private readonly ScrappingService _scrappingService;
        private readonly InventoryTransactionService _inventoryTransactionService;
        private readonly IMapper _mapper;

        public ScrappingItemChildController(
            NumberSequenceService numberSequenceService,
            ScrappingService scrappingService,
            IMapper mapper,
            InventoryTransactionService inventoryTransactionService)
        {
            _mapper = mapper;
            _scrappingService = scrappingService;
            _inventoryTransactionService = inventoryTransactionService;
            _numberSequenceService = numberSequenceService;
        }

        [EnableQuery]
        public IQueryable<ScrappingItemChildDto> Get()
        {
            const string HeaderKeyName = "ParentId";
            Request.Headers.TryGetValue(HeaderKeyName, out var headerValue);
            var parentId = int.Parse(headerValue.ToString());

            var moduleName = nameof(Scrapping) ?? string.Empty;

            return _inventoryTransactionService
                .GetAll()
                .Where(x => x.ModuleId == parentId && x.ModuleName == moduleName)
                .Select(x => _mapper.Map<ScrappingItemChildDto>(x));
        }


        [EnableQuery]
        [HttpGet("{key}")]
        public SingleResult<ScrappingItemChildDto> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_inventoryTransactionService
                .GetAll()
                .Where(x => x.Id == key)
            .Select(x => _mapper.Map<ScrappingItemChildDto>(x)));
        }



        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] int key, [FromBody] Delta<ScrappingItemChildDto> delta)
        {
            try
            {
                var moduleName = nameof(Scrapping) ?? string.Empty;
                var child = await _inventoryTransactionService
                    .GetAll()
                    .Where(x => x.Id == key && x.ModuleName == moduleName)
                    .FirstOrDefaultAsync();

                if (child == null)
                {
                    return NotFound();
                }
                var oldMovement = child.Movement;

                var dto = _mapper.Map<ScrappingItemChildDto>(child);
                delta.Patch(dto);
                var entity = _mapper.Map(dto, child);
                await _inventoryTransactionService.UpdateAsync(entity);

                var warehouseProduct = await _inventoryTransactionService.GetWarehouseProductAsync(entity.WarehouseId, entity.ProductId);
                if (warehouseProduct != null)
                {
                    warehouseProduct.Quantity += (int)oldMovement; // Revert old movement
                    warehouseProduct.Quantity -= (int)entity.Movement; // Apply new movement
                    await _inventoryTransactionService.UpdateWarehouseProductAsync(warehouseProduct);
                }

                return Ok(_mapper.Map<ScrappingItemChildDto>(entity));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScrappingItemChildDto postInput)
        {
            try
            {

                const string HeaderKeyName = "ParentId";
                Request.Headers.TryGetValue(HeaderKeyName, out var headerValue);
                var parentId = int.Parse(headerValue.ToString());
                var moduleName = nameof(Scrapping) ?? string.Empty;


                var entity = _mapper.Map<InventoryTransaction>(postInput);

                var parent = await _scrappingService.GetByIdAsync(parentId);
                if (parent != null)
                {
                    entity.ModuleId = parent.Id;
                    entity.ModuleName = moduleName;
                    entity.ModuleCode = "SCRP";
                    entity.ModuleNumber = parent.Number ?? string.Empty;
                    entity.MovementDate = parent.ScrappingDate!.Value;
                    entity.Status = (InventoryTransactionStatus)parent.Status!;
                    entity.WarehouseId = parent.WarehouseId;
                }

                entity.Number = _numberSequenceService.GenerateNumber(nameof(InventoryTransaction), "", "IVT");
                await _inventoryTransactionService.AddAsync(entity);

                var warehouseProduct = await _inventoryTransactionService.GetWarehouseProductAsync(entity.WarehouseId, entity.ProductId);
                if (warehouseProduct != null)
                {
                    warehouseProduct.Quantity -= (int)entity.Movement;
                    await _inventoryTransactionService.UpdateWarehouseProductAsync(warehouseProduct);
                }

                var dto = _mapper.Map<InventoryTransaction>(entity);
                return Created("ScrappingItemChild", dto);

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
                var child = await _inventoryTransactionService.GetAll()
                    .Where(x => x.Id == key)
                    .FirstOrDefaultAsync();

                if (child == null)
                {
                    return BadRequest();
                }

                var warehouseProduct = await _inventoryTransactionService.GetWarehouseProductAsync(child.WarehouseId, child.ProductId);
                if (warehouseProduct != null)
                {
                    warehouseProduct.Quantity += (int)child.Movement; // Revert movement
                    await _inventoryTransactionService.UpdateWarehouseProductAsync(warehouseProduct);
                }

                await _inventoryTransactionService.DeleteByIdAsync(child.Id);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
