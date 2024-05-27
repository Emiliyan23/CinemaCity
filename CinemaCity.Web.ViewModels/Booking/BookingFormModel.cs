namespace CinemaCity.Web.ViewModels.Booking
{
	using Showtime;

	public class BookingFormModel
	{
		public string UserId { get; set; } = null!;

		public List<int> SelectedTicketsIds { get; set; } = new List<int>();

		public List<TicketViewModel> Tickets { get; set; } = new List<TicketViewModel>();
	}
}
