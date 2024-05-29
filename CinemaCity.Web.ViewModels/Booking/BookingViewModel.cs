namespace CinemaCity.Web.ViewModels.Booking
{
	using Seat;
	using Ticket;

	public class BookingViewModel
	{
        public int MovieId { get; set; }

        public string MovieName { get; set; } = null!;

        public int ShowtimeId { get; set; }

        public DateTime BookingTime { get; set; }

        public DateTime ShowtimeStart { get; set; }

        public List<TicketProfileModel> SelectedTickets { get; set; } = new List<TicketProfileModel>();

        public List<SeatViewModel> SelectedSeats { get; set; } = new List<SeatViewModel>();
    }
}
