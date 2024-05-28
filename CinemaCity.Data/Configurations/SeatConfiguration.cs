using Microsoft.EntityFrameworkCore;

namespace CinemaCity.Data.Configurations
{
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;

	public class SeatConfiguration : IEntityTypeConfiguration<Seat>
	{
		public void Configure(EntityTypeBuilder<Seat> builder)
		{
			builder.HasData(CreateSeats());
		}

		private List<Seat> CreateSeats()
		{
			List<Seat> seats = new List<Seat>();
			int id = 1;
			for(int row = 1;  row <= 5; row++) {
				for(int col = 1; col <= 10; col++) {
					seats.Add(new Seat
					{
						Id = id++,
						CinemaId = 1,
						RowNumber = row,
						ColumnNumber = col
					});
				}
			}

			for (int row = 1; row <= 5; row++)
			{
				for (int col = 1; col <= 10; col++)
				{
					seats.Add(new Seat
					{
						Id = id++,
						CinemaId = 2,
						RowNumber = row,
						ColumnNumber = col
					});
				}
			}

			for (int row = 1; row <= 5; row++)
			{
				for (int col = 1; col <= 10; col++)
				{
					seats.Add(new Seat
					{
						Id = id++,
						CinemaId = 3,
						RowNumber = row,
						ColumnNumber = col
					});
				}
			}

			return seats;
		}
	}
}
