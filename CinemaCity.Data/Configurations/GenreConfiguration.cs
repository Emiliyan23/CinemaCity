namespace CinemaCity.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(CreateGenres());
        }

        private List<Genre> CreateGenres()
        {
            List<Genre> genres = new List<Genre>
            {
                new Genre
                {
                    Id = 1,
                    Name = "Action"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Animation"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Comedy"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Drama"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Horror"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Adventure"
                },
                new Genre
                {
                    Id = 7,
                    Name = "Thriller"
                }
            };

            return genres;
        }
    }
}
