using ProksRent_WebAPI.DTOs;

namespace ProksRent_WebAPI.Services
{
    public interface ITransmissionTypeService
    {
        Task<IEnumerable<TransmissionTypeDto>> GetAllTransmissionTypesAsync();
        Task<TransmissionTypeDto> GetTransmissionTypeByIdAsync(int id);
        Task AddTransmissionTypeAsync(TransmissionTypeDto transmissionTypeDto);
        Task UpdateTransmissionTypeAsync(TransmissionTypeDto transmissionTypeDto);
        Task DeleteTransmissionTypeAsync(int id);
    }
}
