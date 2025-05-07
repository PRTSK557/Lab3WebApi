using ProksRent_WebAPI.DTOs;

namespace ProksRent_WebAPI.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto> GetBookingByIdAsync(int id);
        Task AddBookingAsync(BookingDto bookingDto);
        Task UpdateBookingAsync(BookingDto bookingDto);
        Task DeleteBookingAsync(int id);
    }
}
