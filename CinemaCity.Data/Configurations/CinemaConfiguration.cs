namespace CinemaCity.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasData(CreateCinemas());
        }

        private List<Cinema> CreateCinemas()
        {
            List<Cinema> cinemas = new List<Cinema>
            {
                new Cinema
                {
                    Id = 1,
                    CinemaName = "Cinema City - Sofia",
                    Location = "The Mall Sofia"
                },
                new Cinema
                {
                Id = 2,
                CinemaName = "Cinema City - Varna",
                Location = "Grand Mall Varna"
                },
                new Cinema
                {
                    Id = 3,
                    CinemaName = "Cinema City - Ruse",
                    Location = "Mall Ruse"
                }
            };

            return cinemas;
        }
    }
}
