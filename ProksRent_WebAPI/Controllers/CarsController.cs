using Microsoft.AspNetCore.Mvc;
using ProksRent_WebAPI.DTOs;
using ProksRent_WebAPI.Services;

namespace ProksRent_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            return Ok(cars);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
                return NotFound();
            return Ok(car);
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CarDto carDto)
        {
            await _carService.AddCarAsync(carDto);
            return CreatedAtAction(nameof(GetCarById), new { id = carDto.Id }, carDto);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] CarDto carDto)
        {
            if (id != carDto.Id)
                return BadRequest();

            await _carService.UpdateCarAsync(carDto);
            return NoContent();
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteCarAsync(id);
            return NoContent();
        }
    }
}
