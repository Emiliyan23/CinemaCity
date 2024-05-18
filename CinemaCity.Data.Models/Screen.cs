namespace CinemaCity.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityConstants;

    public class Screen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CinemaId { get; set; }

        [ForeignKey(nameof(CinemaId))]
        public Cinema Cinema { get; set; } = null!;

        [MaxLength(ScreenTypeMaxLen)]
        public string Type { get; set; } = null!;

        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();

        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}
