using ProksRent_WebAPI.DTOs;

namespace ProksRent_WebAPI.Services
{
    public interface IBrandService
    {
        // Get all brands
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

        // Get a brand by ID
        Task<BrandDto> GetBrandByIdAsync(int id);

        // Add a new brand
        Task AddBrandAsync(BrandDto brandDto);

        // Update an existing brand
        Task UpdateBrandAsync(BrandDto brandDto);

        // Delete a brand by ID
        Task DeleteBrandAsync(int id);
    }
}
