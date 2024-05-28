namespace CinemaCity.Services
{
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Interfaces;
	using Web.ViewModels;
	using Web.ViewModels.Showtime;
	using Web.ViewModels.Ticket;

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
				.AsNoTracking()
				.ToListAsync();

			return tickets;
		}

		public async Task<SelectedTicketsModel> GetSelectedTicketsModel()
		{
			SelectedTicketsModel model = new SelectedTicketsModel
			{
				SelectedTickets = await _context.TicketTypes
					.Select(t => new TicketQuantityModel
					{
						TicketId = t.Id,
						Quantity = 0
					})
					.AsNoTracking()
					.ToListAsync()
			};

			return model;
		}

		public async Task<List<SeatViewModel>> GetAllTakenSeats(int showtimeId)
		{
			var allSeats = await _context.Seats
				.Select(s => new SeatViewModel
				{
					Id = s.Id,
					RowNum = s.RowNumber,
					ColNum = s.ColumnNumber
				})
				.AsNoTracking()
				.ToListAsync();

			var bookedSeatIds = await _context.BookingSeats
				.Include(bs => bs.Booking)
				.Where(bs => bs.Booking.ShowtimeId == showtimeId)
				.AsNoTracking()
				.Select(bs => bs.SeatId)
				.ToListAsync();

			return allSeats.Where(s => !bookedSeatIds.Contains(s.Id)).ToList();
		}
	}
}
