namespace CinemaCity.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityConstants;

	public class TicketType
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(TicketTypeMaxLen)]
		public string Type { get; set; } = null!;

		public double Price { get; set; }

		public ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();
	}
}
