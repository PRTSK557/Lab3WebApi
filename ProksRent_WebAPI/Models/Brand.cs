using System.ComponentModel.DataAnnotations;

namespace ProksRent_WebAPI.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Car>? Cars { get; set; }
    }
}
