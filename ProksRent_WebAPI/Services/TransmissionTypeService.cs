using ProksRent_WebAPI.DTOs;
using ProksRent_WebAPI.Models;
using ProksRent_WebAPI.Repositories;

namespace ProksRent_WebAPI.Services
{
    public class TransmissionTypeService : ITransmissionTypeService
    {
        private readonly ITransmissionTypeRepository _transmissionTypeRepository;

        public TransmissionTypeService(ITransmissionTypeRepository transmissionTypeRepository)
        {
            _transmissionTypeRepository = transmissionTypeRepository;
        }

        public async Task<IEnumerable<TransmissionTypeDto>> GetAllTransmissionTypesAsync()
        {
            var transmissionTypes = await _transmissionTypeRepository.GetAllAsync();
            return transmissionTypes.Select(t => new TransmissionTypeDto
            {
                Id = t.Id,
                Name = t.Name
            });
        }

        public async Task<TransmissionTypeDto> GetTransmissionTypeByIdAsync(int id)
        {
            var transmissionType = await _transmissionTypeRepository.GetByIdAsync(id);
            if (transmissionType == null) return null;

            return new TransmissionTypeDto
            {
                Id = transmissionType.Id,
                Name = transmissionType.Name
            };
        }

        public async Task AddTransmissionTypeAsync(TransmissionTypeDto transmissionTypeDto)
        {
            var transmissionType = new TransmissionType
            {
                Name = transmissionTypeDto.Name
            };

            await _transmissionTypeRepository.AddAsync(transmissionType);
        }

        public async Task UpdateTransmissionTypeAsync(TransmissionTypeDto transmissionTypeDto)
        {
            var transmissionType = await _transmissionTypeRepository.GetByIdAsync(transmissionTypeDto.Id);
            if (transmissionType == null) return;

            transmissionType.Name = transmissionTypeDto.Name;

            await _transmissionTypeRepository.UpdateAsync(transmissionType);
        }

        public async Task DeleteTransmissionTypeAsync(int id)
        {
            var transmissionType = await _transmissionTypeRepository.GetByIdAsync(id);
            if (transmissionType != null)
            {
                await _transmissionTypeRepository.DeleteAsync(transmissionType.Id);
            }
        }
    }
}
