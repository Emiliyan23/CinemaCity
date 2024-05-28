namespace CinemaCity.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;

	public class BookingSeatsConfiguration : IEntityTypeConfiguration<BookingSeat>
	{
		public void Configure(EntityTypeBuilder<BookingSeat> builder)
		{
			builder.HasData(CreateBookingSeats());
		}

		private List<BookingSeat> CreateBookingSeats()
		{
			return new List<BookingSeat>
			{
				new BookingSeat
				{
					BookingId = 1,
					SeatId = 1
				},
				new BookingSeat
				{
					BookingId = 1,
					SeatId = 2
				},
				new BookingSeat
				{
					BookingId = 1,
					SeatId = 3
				},
				new BookingSeat
				{
					BookingId = 2,
					SeatId = 11
				},
				new BookingSeat
				{
					BookingId = 2,
					SeatId = 12
				},
				new BookingSeat
				{
					BookingId = 2,
					SeatId = 13
				}
			};
		}
	}
}
