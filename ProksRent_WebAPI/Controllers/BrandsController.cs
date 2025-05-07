using Microsoft.AspNetCore.Mvc;
using ProksRent_WebAPI.DTOs;
using ProksRent_WebAPI.Services;

namespace ProksRent_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            return Ok(brands);
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var brand = await _brandService.GetBrandByIdAsync(id);
            if (brand == null)
                return NotFound();
            return Ok(brand);
        }

        // POST: api/Brands
        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] BrandDto brandDto)
        {
            await _brandService.AddBrandAsync(brandDto);
            return CreatedAtAction(nameof(GetBrandById), new { id = brandDto.Id }, brandDto);
        }

        // PUT: api/Brands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] BrandDto brandDto)
        {
            if (id != brandDto.Id)
                return BadRequest();

            await _brandService.UpdateBrandAsync(brandDto);
            return NoContent();
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandService.DeleteBrandAsync(id);
            return NoContent();
        }
    }
}
