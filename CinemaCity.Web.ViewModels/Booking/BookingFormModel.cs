namespace CinemaCity.Web.ViewModels.Booking
{
	using Showtime;
	using Ticket;

	public class BookingFormModel
	{
		public string UserId { get; set; } = null!;

		public int ShowtimeId { get; set; }

		public string MovieTitle { get; set; } = null!;

		public string ImagePath { get; set; } = null!;

		public SelectedTicketsModel SelectedTickets { get; set; } = null!;

		public List<SeatViewModel> TakenSeats { get; set; } = new List<SeatViewModel>();
		
		public List<TicketViewModel> TicketTypes { get; set; } = new List<TicketViewModel>();
	}
}
