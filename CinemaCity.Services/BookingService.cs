namespace CinemaCity.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Interfaces;
    using Web.ViewModels;
    using Web.ViewModels.Booking;
    using Web.ViewModels.Showtime;
    using Web.ViewModels.Ticket;
    using CinemaCity.Web.ViewModels.Seat;

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

			return allSeats.Where(s => bookedSeatIds.Contains(s.Id)).ToList();
		}

		public async Task AddBooking(BookingFormModel model, string userId)
		{
			var booking = new Booking
			{
				ShowtimeId = model.ShowtimeId,
				UserId = userId,
				BookingDate = DateTime.Now,
			};

			await _context.Bookings.AddAsync(booking);
			await _context.SaveChangesAsync();

			int bookingId = booking.Id;
			var bookingSeats = model.SelectedSeats
				.Select(s => new BookingSeat
				{
					SeatId = s,
					BookingId = bookingId
				})
				.ToList();
			await _context.BookingSeats.AddRangeAsync(bookingSeats);

			var bookingTickets = model.SelectedTickets.SelectedTickets
				.Where(t => t.Quantity > 0)
				.Select(t => new BookingTicket
				{
					TicketTypeId = t.TicketId,
					Quantity = t.Quantity,
					BookingId = bookingId
				})
				.ToList();
			await _context.BookingTickets.AddRangeAsync(bookingTickets);

			await _context.SaveChangesAsync();
		}
	}
}
