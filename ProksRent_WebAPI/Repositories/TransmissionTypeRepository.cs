using Microsoft.EntityFrameworkCore;
using ProksRent_WebAPI.Models;
using PROKSRent_WebAPI.Data;

namespace ProksRent_WebAPI.Repositories
{
    public class TransmissionTypeRepository : ITransmissionTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TransmissionTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransmissionType>> GetAllAsync()
        {
            return await _context.TransmissionTypes.ToListAsync();
        }

        public async Task<TransmissionType> GetByIdAsync(int id)
        {
            return await _context.TransmissionTypes.FindAsync(id);
        }

        public async Task AddAsync(TransmissionType transmissionType)
        {
            await _context.TransmissionTypes.AddAsync(transmissionType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TransmissionType transmissionType)
        {
            _context.TransmissionTypes.Update(transmissionType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transmissionType = await GetByIdAsync(id);
            if (transmissionType != null)
            {
                _context.TransmissionTypes.Remove(transmissionType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
