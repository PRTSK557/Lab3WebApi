using ProksRent_WebAPI.DTOs;
using ProksRent_WebAPI.Models;
using ProksRent_WebAPI.Repositories;

namespace ProksRent_WebAPI.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        // Get all brands asynchronously
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            return brands.Select(b => new BrandDto
            {
                Id = b.Id,
                Name = b.Name
            });
        }

        // Get a brand by ID asynchronously
        public async Task<BrandDto> GetBrandByIdAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null) return null;

            return new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }

        // Add a new brand asynchronously
        public async Task AddBrandAsync(BrandDto brandDto)
        {
            var brand = new Brand
            {
                Name = brandDto.Name
            };

            await _brandRepository.AddAsync(brand);
        }

        // Update an existing brand asynchronously
        public async Task UpdateBrandAsync(BrandDto brandDto)
        {
            var brand = await _brandRepository.GetByIdAsync(brandDto.Id);
            if (brand == null) return;

            brand.Name = brandDto.Name;

            await _brandRepository.UpdateAsync(brand);
        }

        // Delete a brand by ID asynchronously
        public async Task DeleteBrandAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand != null)
            {
                await _brandRepository.DeleteAsync(id);
            }
        }
    }
}
