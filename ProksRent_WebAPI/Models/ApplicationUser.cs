using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PROKSRent_WebAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
