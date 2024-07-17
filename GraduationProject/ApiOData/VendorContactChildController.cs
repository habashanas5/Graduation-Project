using AutoMapper;
using GraduationProject.Applications.NumberSequences;
using GraduationProject.Applications.VendorContacts;
using GraduationProject.DTOS;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GraduationProject.ApiOData
{
    [Route("api/[controller]")]
    public class VendorContactChildController : ODataController
    {

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<FactoriesContacts, FactoriesContactChildDto>();
                CreateMap<FactoriesContactChildDto, FactoriesContacts>();
            }
        }


        private readonly VendorContactService _vendorContactService;
        private readonly NumberSequenceService _numberSequenceService;
        private readonly IMapper _mapper;

        public VendorContactChildController(
            IMapper mapper,
            VendorContactService vendorContactService,
            NumberSequenceService numberSequenceService)
        {
            _mapper = mapper;
            _vendorContactService = vendorContactService;
            _numberSequenceService = numberSequenceService;
        }

        [EnableQuery]
        public IQueryable<FactoriesContactChildDto> Get()
        {
            const string HeaderKeyName = "ParentId";
            Request.Headers.TryGetValue(HeaderKeyName, out var headerValue);
            var parentId = int.Parse(headerValue.ToString());

            return _vendorContactService
                .GetAll()
                .Where(x => x.VendorId == parentId)
                .Select(x => _mapper.Map<FactoriesContactChildDto>(x));
        }


        [EnableQuery]
        [HttpGet("{key}")]
        public SingleResult<FactoriesContactChildDto> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_vendorContactService
                .GetAll()
                .Where(x => x.Id == key)
                .Select(x => _mapper.Map<FactoriesContactChildDto>(x)));
        }



        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] int key, [FromBody] Delta<FactoriesContactChildDto> delta)
        {
            try
            {
                var vendorContact = await _vendorContactService.GetByIdAsync(key);
                if (vendorContact == null)
                {
                    return NotFound();
                }

                var dto = _mapper.Map<FactoriesContactChildDto>(vendorContact);
                delta.Patch(dto);
                var entity = _mapper.Map(dto, vendorContact);
                await _vendorContactService.UpdateAsync(entity);

                return Ok(_mapper.Map<FactoriesContactChildDto>(entity));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FactoriesContactChildDto vendorContact)
        {
            try
            {

                const string HeaderKeyName = "ParentId";
                Request.Headers.TryGetValue(HeaderKeyName, out var headerValue);
                var parentId = int.Parse(headerValue.ToString());

                vendorContact.FactoryId = parentId;
                vendorContact.Number = _numberSequenceService.GenerateNumber(nameof(FactoriesContacts), "", "CC");
                var entity = _mapper.Map<FactoriesContacts>(vendorContact);
                await _vendorContactService.AddAsync(entity);
                var dto = _mapper.Map<FactoriesContacts>(entity);

                return Created("VendorContactChild", dto);

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
                var vendorContact = await _vendorContactService.GetByIdAsync(key);
                if (vendorContact == null)
                {
                    return BadRequest();
                }

                await _vendorContactService.DeleteByIdAsync(vendorContact.Id);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
