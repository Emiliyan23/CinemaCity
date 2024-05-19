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
                    StartTime = new DateTime(2024, 5, 20, 12, 0, 0),
                    MovieId = 1,
                    CinemaId = 1
                },
                new Showtime
                {
                    Id = 2,
                    StartTime = new DateTime(2024, 5, 20, 19, 0, 0),
                    MovieId = 1,
                    CinemaId = 1
                },
                new Showtime
                {
                    Id = 3,
                    StartTime = new DateTime(2024, 5, 21, 11, 0, 0),
                    MovieId = 2,
                    CinemaId = 2
                },
                new Showtime
                {
                    Id = 4,
                    StartTime = new DateTime(2024, 5, 21, 14, 0, 0),
                    MovieId = 3,
                    CinemaId = 2
                },
                new Showtime
                {
                    Id = 5,
                    StartTime = new DateTime(2024, 5, 21, 18, 0, 0),
                    MovieId = 4,
                    CinemaId = 3
                },
            };
        }
    }
}
