using Microsoft.EntityFrameworkCore;
using ProksRent_WebAPI.Models;
using PROKSRent_WebAPI.Data;

namespace ProksRent_WebAPI.Repositories
{
    public class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public FuelTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FuelType>> GetAllAsync()
        {
            return await _context.FuelTypes.ToListAsync();
        }

        public async Task<FuelType> GetByIdAsync(int id)
        {
            return await _context.FuelTypes.FindAsync(id);
        }

        public async Task AddAsync(FuelType fuelType)
        {
            await _context.FuelTypes.AddAsync(fuelType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FuelType fuelType)
        {
            _context.FuelTypes.Update(fuelType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fuelType = await GetByIdAsync(id);
            if (fuelType != null)
            {
                _context.FuelTypes.Remove(fuelType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
