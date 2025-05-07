using ProksRent_WebAPI.DTOs;

namespace ProksRent_WebAPI.Services
{
    public interface IFuelTypeService
    {
        Task<IEnumerable<FuelTypeDto>> GetAllFuelTypesAsync();
        Task<FuelTypeDto> GetFuelTypeByIdAsync(int id);
        Task AddFuelTypeAsync(FuelTypeDto fuelTypeDto);
        Task UpdateFuelTypeAsync(FuelTypeDto fuelTypeDto);
        Task DeleteFuelTypeAsync(int id);
    }
}
