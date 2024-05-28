namespace CinemaCity.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class BookingTicket
	{
		[Key]
		public int Id { get; set; }

		public int BookingId { get; set; }

		[ForeignKey(nameof(BookingId))]
		public Booking Booking { get; set; } = null!;

		public int TicketTypeId { get; set; }

		[ForeignKey(nameof(TicketTypeId))]
		public TicketType TicketType { get; set; } = null!;

		public int Quantity { get; set; }
	}
}
