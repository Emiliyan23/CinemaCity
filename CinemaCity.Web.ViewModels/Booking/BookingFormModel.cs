namespace CinemaCity.Web.ViewModels.Booking
{
    using Seat;
    using Showtime;
    using Ticket;

    public class BookingFormModel
	{
		public int ShowtimeId { get; set; }

		public string MovieTitle { get; set; } = null!;

		public string ImagePath { get; set; } = null!;

		public SelectedTicketsModel SelectedTickets { get; set; } = null!;

		public List<SeatViewModel> TakenSeats { get; set; } = new List<SeatViewModel>();

		public List<int> SelectedSeats { get; set; } = new List<int>();
		
		public List<TicketViewModel> TicketTypes { get; set; } = new List<TicketViewModel>();
	}
}
