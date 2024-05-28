namespace CinemaCity.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;

	public class BookingTicketConfiguration : IEntityTypeConfiguration<BookingTicket>
	{
		public void Configure(EntityTypeBuilder<BookingTicket> builder)
		{
			builder.HasData(CreateBookingTickets());
		}

		private List<BookingTicket> CreateBookingTickets()
		{
			return new List<BookingTicket>
			{
				new BookingTicket
				{
					Id = 1,
					BookingId = 1,
					TicketTypeId = 1,
					Quantity = 3
				},
				new BookingTicket
				{
					Id = 2,
					BookingId = 2,
					TicketTypeId = 1,
					Quantity = 1
				},
				new BookingTicket
				{
					Id = 3,
					BookingId = 2,
					TicketTypeId = 2,
					Quantity = 2
				}
			};
		}
	}
}
