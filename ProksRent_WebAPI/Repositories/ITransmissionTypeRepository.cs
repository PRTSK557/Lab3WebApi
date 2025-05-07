using ProksRent_WebAPI.Models;
using PROKSRent_WebAPI.Models;

public interface ITransmissionTypeRepository
{
    Task<IEnumerable<TransmissionType>> GetAllAsync();
    Task<TransmissionType?> GetByIdAsync(int id);
    Task AddAsync(TransmissionType type);
    Task UpdateAsync(TransmissionType type);
    Task DeleteAsync(int id);
}