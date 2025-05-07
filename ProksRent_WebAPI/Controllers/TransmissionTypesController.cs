using Microsoft.AspNetCore.Mvc;
using ProksRent_WebAPI.DTOs;
using ProksRent_WebAPI.Services;

namespace ProksRent_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionTypesController : ControllerBase
    {
        private readonly ITransmissionTypeService _transmissionTypeService;

        public TransmissionTypesController(ITransmissionTypeService transmissionTypeService)
        {
            _transmissionTypeService = transmissionTypeService;
        }

        // GET: api/TransmissionTypes
        [HttpGet]
        public async Task<IActionResult> GetAllTransmissionTypes()
        {
            var transmissionTypes = await _transmissionTypeService.GetAllTransmissionTypesAsync();
            return Ok(transmissionTypes);
        }

        // GET: api/TransmissionTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransmissionTypeById(int id)
        {
            var transmissionType = await _transmissionTypeService.GetTransmissionTypeByIdAsync(id);
            if (transmissionType == null)
                return NotFound();
            return Ok(transmissionType);
        }

        // POST: api/TransmissionTypes
        [HttpPost]
        public async Task<IActionResult> AddTransmissionType([FromBody] TransmissionTypeDto transmissionTypeDto)
        {
            await _transmissionTypeService.AddTransmissionTypeAsync(transmissionTypeDto);
            return CreatedAtAction(nameof(GetTransmissionTypeById), new { id = transmissionTypeDto.Id }, transmissionTypeDto);
        }

        // PUT: api/TransmissionTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransmissionType(int id, [FromBody] TransmissionTypeDto transmissionTypeDto)
        {
            if (id != transmissionTypeDto.Id)
                return BadRequest();

            await _transmissionTypeService.UpdateTransmissionTypeAsync(transmissionTypeDto);
            return NoContent();
        }

        // DELETE: api/TransmissionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransmissionType(int id)
        {
            await _transmissionTypeService.DeleteTransmissionTypeAsync(id);
            return NoContent();
        }
    }
}
