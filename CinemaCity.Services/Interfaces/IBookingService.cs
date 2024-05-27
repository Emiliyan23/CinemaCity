namespace CinemaCity.Services.Interfaces
{
	using Web.ViewModels.Showtime;

	public interface IBookingService
	{
		Task<List<TicketViewModel>> GetTicketTypes();
	}
}
