using ProksRent_WebAPI.Models;

public interface IFuelTypeRepository
{
    Task<IEnumerable<FuelType>> GetAllAsync();
    Task<FuelType?> GetByIdAsync(int id);
    Task AddAsync(FuelType fuelType);
    Task UpdateAsync(FuelType fuelType);
    Task DeleteAsync(int id);
}