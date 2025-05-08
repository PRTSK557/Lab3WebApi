using Microsoft.EntityFrameworkCore;
using PROKSRent_WebAPI.Data;
using PROKSRent_WebAPI.Models;

namespace ProksRent_WebAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings.Include(b => b.Car).Include(b => b.User).ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _context.Bookings.Include(b => b.Car).Include(b => b.User).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await GetByIdAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
