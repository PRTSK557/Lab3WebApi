using ProksRent_WebAPI.DTOs;

namespace ProksRent_WebAPI.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllCarsAsync();
        Task<CarDto> GetCarByIdAsync(int id);
        Task AddCarAsync(CarDto carDto);
        Task UpdateCarAsync(CarDto carDto);
        Task DeleteCarAsync(int id);
    }
}
