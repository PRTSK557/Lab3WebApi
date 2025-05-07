using Microsoft.AspNetCore.Mvc;
using ProksRent_WebAPI.DTOs;
using ProksRent_WebAPI.Services;

namespace ProksRent_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] BookingDto bookingDto)
        {
            await _bookingService.AddBookingAsync(bookingDto);
            return CreatedAtAction(nameof(GetBookingById), new { id = bookingDto.Id }, bookingDto);
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingDto bookingDto)
        {
            if (id != bookingDto.Id)
                return BadRequest();

            await _bookingService.UpdateBookingAsync(bookingDto);
            return NoContent();
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return NoContent();
        }
    }
}
