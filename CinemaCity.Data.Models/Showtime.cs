namespace CinemaCity.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Showtime
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        [Required]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;

        public int ScreenId { get; set; }

        [ForeignKey(nameof(ScreenId))]
        public Screen Screen { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
