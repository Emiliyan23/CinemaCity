namespace CinemaCity.Services
{
	using Data;
	using Interfaces;
	using Microsoft.EntityFrameworkCore;

	public class SeatService : ISeatService
	{
		private readonly CinemaCityContext _context;
		public SeatService(CinemaCityContext context)
		{
			_context = context;
		}

		public async Task<int> GetSeatId(int row, int col)
		{
			int seatId = await _context.Seats
				.Where(s => s.RowNumber == row && s.ColumnNumber == col)
				.Select(s => s.Id)
				.FirstOrDefaultAsync();

			return seatId;
		}
	}
}
