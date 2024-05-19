namespace CinemaCity.Data.Models
{
	using System.ComponentModel.DataAnnotations.Schema;

	public class BookingSeat
	{
		public int BookingId { get; set; }

		[ForeignKey(nameof(BookingId))]
		public Booking Booking { get; set; } = null!;

		public int SeatId { get; set; }

		[ForeignKey(nameof(SeatId))]
		public Seat Seat { get; set; } = null!;

		public int TicketTypeId { get; set; }

		[ForeignKey(nameof(TicketTypeId))]
		public TicketType TicketType { get; set; } = null!;
	}
}
