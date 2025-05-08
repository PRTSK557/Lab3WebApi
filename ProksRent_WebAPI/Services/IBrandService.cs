using ProksRent_WebAPI.DTOs;

namespace ProksRent_WebAPI.Services
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        Task<BrandDto> GetBrandByIdAsync(int id);
        Task AddBrandAsync(BrandDto brandDto);
        Task UpdateBrandAsync(BrandDto brandDto);
        Task DeleteBrandAsync(int id);
    }
}
