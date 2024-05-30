namespace CinemaCity.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class ShowtimeConfiguration : IEntityTypeConfiguration<Showtime>
    {
        public void Configure(EntityTypeBuilder<Showtime> builder)
        {
            builder.HasData(CreateShowtimes());
        }

        private List<Showtime> CreateShowtimes()
        {
            return new List<Showtime>
            {
                new Showtime
                {
                    Id = 1,
                    StartTime = new DateTime(2024, 5, 31, 12, 0, 0),
                    MovieId = 1,
                    CinemaId = 1
                },
                new Showtime
                {
	                Id = 2,
	                StartTime = new DateTime(2024, 5, 31, 12, 0, 0),
	                MovieId = 1,
	                CinemaId = 2
                },
                new Showtime
                {
	                Id = 3,
	                StartTime = new DateTime(2024, 5, 31, 12, 0, 0),
	                MovieId = 1,
	                CinemaId = 3
                },
                new Showtime
                {
	                Id = 4,
	                StartTime = new DateTime(2024, 6, 1, 12, 0, 0),
	                MovieId = 1,
	                CinemaId = 1
                },
                new Showtime
                {
	                Id = 5,
	                StartTime = new DateTime(2024, 6, 1, 12, 0, 0),
	                MovieId = 1,
	                CinemaId = 2
                },
                new Showtime
                {
	                Id = 6,
	                StartTime = new DateTime(2024, 6, 1, 12, 0, 0),
	                MovieId = 1,
	                CinemaId = 3
                },
                new Showtime
                {
	                Id = 7,
	                StartTime = new DateTime(2024, 5, 31, 14, 30, 0),
	                MovieId = 2,
	                CinemaId = 1
                },
                new Showtime
                {
	                Id = 8,
	                StartTime = new DateTime(2024, 5, 31, 14, 30, 0),
	                MovieId = 2,
	                CinemaId = 2
                },
                new Showtime
                {
	                Id = 9,
	                StartTime = new DateTime(2024, 5, 31, 14, 30, 0),
	                MovieId = 2,
	                CinemaId = 3
                },
                new Showtime
                {
	                Id = 10,
	                StartTime = new DateTime(2024, 6, 1, 15, 0, 0),
	                MovieId = 3,
	                CinemaId = 1
                },
                new Showtime
                {
	                Id = 11,
	                StartTime = new DateTime(2024, 6, 1, 15, 0, 0),
	                MovieId = 3,
	                CinemaId = 2
                },
                new Showtime
                {
	                Id = 12,
	                StartTime = new DateTime(2024, 6, 1, 15, 0, 0),
	                MovieId = 3,
	                CinemaId = 3
                },
                new Showtime
                {
	                Id = 13,
	                StartTime = new DateTime(2024, 6, 1, 18, 0, 0),
	                MovieId = 4,
	                CinemaId = 1
                },
                new Showtime
                {
	                Id = 14,
	                StartTime = new DateTime(2024, 6, 1, 18, 0, 0),
	                MovieId = 4,
	                CinemaId = 2
                },
                new Showtime
                {
	                Id = 15,
	                StartTime = new DateTime(2024, 6, 1, 18, 0, 0),
	                MovieId = 4,
	                CinemaId = 3
                },
                new Showtime
                {
	                Id = 16,
	                StartTime = new DateTime(2024, 5, 31, 17, 0, 0),
	                MovieId = 5,
	                CinemaId = 1
                },
                new Showtime
                {
	                Id = 17,
	                StartTime = new DateTime(2024, 5, 31, 17, 0, 0),
	                MovieId = 5,
	                CinemaId = 2
                },
                new Showtime
                {
	                Id = 18,
	                StartTime = new DateTime(2024, 5, 31, 17, 0, 0),
	                MovieId = 5,
	                CinemaId = 3
                },
                new Showtime
                {
	                Id = 19,
	                StartTime = new DateTime(2024, 6, 2, 12, 0, 0),
	                MovieId = 6,
	                CinemaId = 1
                },
                new Showtime
                {
	                Id = 20,
	                StartTime = new DateTime(2024, 6, 2, 12, 0, 0),
	                MovieId = 6,
	                CinemaId = 2
                },
                new Showtime
                {
	                Id = 21,
	                StartTime = new DateTime(2024, 6, 2, 12, 0, 0),
	                MovieId = 6,
	                CinemaId = 3
                }
			};
        }
    }
}
