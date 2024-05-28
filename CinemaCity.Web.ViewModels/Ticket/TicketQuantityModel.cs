namespace CinemaCity.Web.ViewModels.Ticket
{
	using System.ComponentModel.DataAnnotations;

	public class TicketQuantityModel
	{
		public int TicketId { get; set; }

		[Range(0, 10)]
		public int Quantity { get; set; }
	}
}
