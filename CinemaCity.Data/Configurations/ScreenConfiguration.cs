namespace CinemaCity.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ScreenConfiguration : IEntityTypeConfiguration<Screen>
    {
        public void Configure(EntityTypeBuilder<Screen> builder)
        {
            builder.HasData(CreateScreens());
        }

        private List<Screen> CreateScreens()
        {
            List<Screen> screens = new List<Screen>
            {
                new Screen
                {
                    Id = 1,
                    CinemaId = 1,
                    Type = "2D"
                },
                new Screen
                {
                    Id = 2,
                    CinemaId = 2,
                    Type = "2D"
                },
                new Screen
                {
                    Id = 3,
                    CinemaId = 3,
                    Type = "2D"
                },
                new Screen
                {
                    Id = 4,
                    CinemaId = 1,
                    Type = "3D"
                },
                new Screen
                {
                    Id = 5,
                    CinemaId = 2,
                    Type = "3D"
                },
                new Screen
                {
                    Id = 6,
                    CinemaId = 3,
                    Type = "3D"
                },
                new Screen
                {
                    Id = 7,
                    CinemaId = 2,
                    Type = "4D"
                }
            };

            return screens;
        }
    }
}
