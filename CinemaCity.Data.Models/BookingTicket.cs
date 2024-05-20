namespace CinemaCity.Data.Models
{
	using System.ComponentModel.DataAnnotations.Schema;

	public class BookingTicket
	{
		public int BookingId { get; set; }

		[ForeignKey(nameof(BookingId))]
		public Booking Booking { get; set; } = null!;

		public int TicketTypeId { get; set; }

		[ForeignKey(nameof(TicketTypeId))]
		public TicketType TicketType { get; set; } = null!;
	}
}
