namespace CinemaCity.Services.Interfaces
{
	using Web.ViewModels;
	using Web.ViewModels.Booking;
	using Web.ViewModels.Showtime;
	using Web.ViewModels.Ticket;

	public interface IBookingService
	{
		Task<List<TicketViewModel>> GetTicketTypes();

		Task<SelectedTicketsModel> GetSelectedTicketsModel();

		Task<List<SeatViewModel>> GetAllTakenSeats(int showtimeId);

		Task AddBooking(BookingFormModel model, string userId);
	}
}
