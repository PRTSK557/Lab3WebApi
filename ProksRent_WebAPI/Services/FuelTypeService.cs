using ProksRent_WebAPI.DTOs;
using ProksRent_WebAPI.Models;
using ProksRent_WebAPI.Repositories;

namespace ProksRent_WebAPI.Services
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly IFuelTypeRepository _fuelTypeRepository;

        public FuelTypeService(IFuelTypeRepository fuelTypeRepository)
        {
            _fuelTypeRepository = fuelTypeRepository;
        }

        public async Task<IEnumerable<FuelTypeDto>> GetAllFuelTypesAsync()
        {
            var fuelTypes = await _fuelTypeRepository.GetAllAsync();
            return fuelTypes.Select(f => new FuelTypeDto
            {
                Id = f.Id,
                Name = f.Name
            });
        }

        public async Task<FuelTypeDto> GetFuelTypeByIdAsync(int id)
        {
            var fuelType = await _fuelTypeRepository.GetByIdAsync(id);
            if (fuelType == null) return null;

            return new FuelTypeDto
            {
                Id = fuelType.Id,
                Name = fuelType.Name
            };
        }

        public async Task AddFuelTypeAsync(FuelTypeDto fuelTypeDto)
        {
            var fuelType = new FuelType
            {
                Name = fuelTypeDto.Name
            };

            await _fuelTypeRepository.AddAsync(fuelType);
        }

        public async Task UpdateFuelTypeAsync(FuelTypeDto fuelTypeDto)
        {
            var fuelType = await _fuelTypeRepository.GetByIdAsync(fuelTypeDto.Id);
            if (fuelType == null) return;

            fuelType.Name = fuelTypeDto.Name;

            await _fuelTypeRepository.UpdateAsync(fuelType);
        }

        public async Task DeleteFuelTypeAsync(int id)
        {
            var fuelType = await _fuelTypeRepository.GetByIdAsync(id);
            if (fuelType != null)
            {
                await _fuelTypeRepository.DeleteAsync(fuelType.Id);
            }
        }
    }
}
