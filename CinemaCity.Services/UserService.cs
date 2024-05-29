namespace CinemaCity.Services
{
	using Data;
	using Interfaces;
	using Microsoft.EntityFrameworkCore;
	using Web.ViewModels.Booking;
	using Web.ViewModels.Seat;
	using Web.ViewModels.Showtime;
	using Web.ViewModels.Ticket;
	using Web.ViewModels.User;

	public class UserService : IUserService
	{
		private readonly CinemaCityContext _context;
		public UserService(CinemaCityContext context) 
		{
			_context = context;
		}

		public async Task<UserProfileModel> GetUserProfile(string userId)
		{
			var user = await _context.Users
				.Include(u => u.Bookings)
				.ThenInclude(b => b.BookingSeats).ThenInclude(bookingSeat => bookingSeat.Seat)
				.Include(applicationUser => applicationUser.Bookings).ThenInclude(booking => booking.Showtime)
				.ThenInclude(showtime => showtime.Movie)
				.Include(u => u.Bookings)
				.ThenInclude(b => b.BookingTickets).ThenInclude(bookingTicket => bookingTicket.TicketType)
				.FirstOrDefaultAsync(u => u.Id == userId);

			var profileModel = new UserProfileModel
			{
				UserId = user!.Id,
				Username = user.UserName!,
				Bookings = user.Bookings.Select(b => new BookingViewModel
				{
					MovieId = b.Showtime.MovieId,
					MovieName = b.Showtime.Movie.Title,
					ShowtimeId = b.ShowtimeId,
					ShowtimeStart = b.Showtime.StartTime,
					BookingTime = b.BookingDate,
					SelectedTickets = b.BookingTickets.Select(bt => new TicketProfileModel
					{
						Type = bt.TicketType.Type,
						Quantity = bt.Quantity,
						Price = bt.TicketType.Price
					}).ToList(),
					SelectedSeats = b.BookingSeats.Select(bs => new SeatViewModel
					{
						RowNum = bs.Seat.RowNumber,
						ColNum = bs.Seat.ColumnNumber
					}).ToList()
				}).ToList()
			};

			return profileModel;
		}

		public async Task<bool> UserExistsById(string userId)
		{
			bool exists = await _context.Users.AnyAsync(u => u.Id == userId);

			return exists;
		}
	}
}
