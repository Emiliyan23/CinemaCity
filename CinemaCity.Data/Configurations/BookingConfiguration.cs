namespace CinemaCity.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;

	public class BookingConfiguration : IEntityTypeConfiguration<Booking>
	{
		public void Configure(EntityTypeBuilder<Booking> builder)
		{
			builder.HasData(CreateBookings());
		}

		private List<Booking> CreateBookings()
		{
			return new List<Booking>
			{
				new Booking
				{
					Id = 1,
					BookingDate = new DateTime(2024, 5, 28, 11, 36, 12),
					ShowtimeId = 1,
					UserId = "acc2665f-25bd-43f8-87e5-6027c253b3cc"
				},
				new Booking
				{
					Id = 2,
					BookingDate = new DateTime(2024, 5, 28, 11, 40, 12),
					ShowtimeId = 1,
					UserId = "acc2665f-25bd-43f8-87e5-6027c253b3cc"
				}
			};

		}
	}
}
