namespace CinemaCity.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ScreenId { get; set; }

        [ForeignKey(nameof(ScreenId))]
        public Screen Screen { get; set; } = null!;

        public int RowNumber { get; set; }

        public int ColumnNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
