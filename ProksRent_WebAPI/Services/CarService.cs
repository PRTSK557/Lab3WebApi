using ProksRent_WebAPI.DTOs;
using ProksRent_WebAPI.Models;
using ProksRent_WebAPI.Repositories;
using AutoMapper;

namespace ProksRent_WebAPI.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        // Замінили List<CarDto> на IEnumerable<CarDto> для відповідності інтерфейсу
        public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarDto>>(cars); // Повертаємо IEnumerable<CarDto> як в інтерфейсі
        }

        public async Task<CarDto> GetCarByIdAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            return _mapper.Map<CarDto>(car);
        }

        public async Task AddCarAsync(CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            await _carRepository.AddAsync(car);
        }

        public async Task UpdateCarAsync(CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            await _carRepository.UpdateAsync(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carRepository.DeleteAsync(id);
        }
    }
}
