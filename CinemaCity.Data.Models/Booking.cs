namespace CinemaCity.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityConstants;

    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public int ShowtimeId { get; set; }

        [ForeignKey(nameof(ShowtimeId))]
        public Showtime Showtime { get; set; } = null!;

        public DateTime BookingDate { get; set; }

        [Required]
        [MaxLength(UserIdMaxLen)]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();

        public ICollection<BookingTicket> BookingTickets { get; set; } = new List<BookingTicket>();
    }
}
