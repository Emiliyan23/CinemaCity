namespace CinemaCity.Web.ViewModels.Ticket
{
	public class TicketProfileModel
	{
		public string Type { get; set; } = null!;

		public int Quantity { get; set; }
		
		public double Price { get; set; }
	}
}
