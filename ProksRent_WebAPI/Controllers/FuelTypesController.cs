using Microsoft.AspNetCore.Mvc;
using ProksRent_WebAPI.DTOs;
using ProksRent_WebAPI.Services;

namespace ProksRent_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypesController : ControllerBase
    {
        private readonly IFuelTypeService _fuelTypeService;

        public FuelTypesController(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        // GET: api/FuelTypes
        [HttpGet]
        public async Task<IActionResult> GetAllFuelTypes()
        {
            var fuelTypes = await _fuelTypeService.GetAllFuelTypesAsync();
            return Ok(fuelTypes);
        }

        // GET: api/FuelTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuelTypeById(int id)
        {
            var fuelType = await _fuelTypeService.GetFuelTypeByIdAsync(id);
            if (fuelType == null)
                return NotFound();
            return Ok(fuelType);
        }

        // POST: api/FuelTypes
        [HttpPost]
        public async Task<IActionResult> AddFuelType([FromBody] FuelTypeDto fuelTypeDto)
        {
            await _fuelTypeService.AddFuelTypeAsync(fuelTypeDto);
            return CreatedAtAction(nameof(GetFuelTypeById), new { id = fuelTypeDto.Id }, fuelTypeDto);
        }

        // PUT: api/FuelTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFuelType(int id, [FromBody] FuelTypeDto fuelTypeDto)
        {
            if (id != fuelTypeDto.Id)
                return BadRequest();

            await _fuelTypeService.UpdateFuelTypeAsync(fuelTypeDto);
            return NoContent();
        }

        // DELETE: api/FuelTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuelType(int id)
        {
            await _fuelTypeService.DeleteFuelTypeAsync(id);
            return NoContent();
        }
    }
}
