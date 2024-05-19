namespace CinemaCity.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
	{
		public void Configure(EntityTypeBuilder<TicketType> builder)
		{
			builder.HasData(CreateTicketTypes());
		}

		private List<TicketType> CreateTicketTypes()
		{
			return new List<TicketType>
			{
				new TicketType
				{
					Id = 1,
					Type = "Adult",
					Price = 16.5
				},
				new TicketType
				{
					Id = 2,
					Type = "Child or student",
					Price = 13
				},
				new TicketType
				{
					Id = 3,
					Type = "Elderly",
					Price = 13
				},
				new TicketType
				{
					Id = 4,
					Type = "Disabled",
					Price = 13
				}
			};
		}
	}
}
