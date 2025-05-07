namespace ProksRent_WebAPI.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsConfirmed { get; set; }

        public int CarId { get; set; }
        public string UserId { get; set; }

        public string? CarModel { get; set; } // для зручності, необов'язково
        public string? UserName { get; set; } // для зручності, необов'язково
    }
}
