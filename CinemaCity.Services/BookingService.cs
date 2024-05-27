namespace CinemaCity.Services
{
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Interfaces;
	using Web.ViewModels.Showtime;

	public class BookingService : IBookingService
	{
		private readonly CinemaCityContext _context;

        public BookingService(CinemaCityContext context)
        {
			_context = context;
        }

        public async Task<List<TicketViewModel>> GetTicketTypes()
		{
			var tickets = await _context.TicketTypes
				.Select(t => new TicketViewModel
				{
					Id = t.Id,
					Type = t.Type,
					Price = t.Price
				})
				.ToListAsync();

			return tickets;
		}
	}
}
