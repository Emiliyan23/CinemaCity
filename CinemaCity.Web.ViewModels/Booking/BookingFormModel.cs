namespace CinemaCity.Web.ViewModels.Booking
{
	using Showtime;

	public class BookingFormModel
	{
		public List<int> TicketsIds { get; set; } = new List<int>();

		public List<TicketViewModel> Tickets { get; set; } = new List<TicketViewModel>();
	}
}
