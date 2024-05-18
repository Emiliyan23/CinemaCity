namespace CinemaCity.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
