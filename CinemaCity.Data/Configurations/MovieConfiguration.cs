namespace CinemaCity.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(CreateMovies());
        }

        private List<Movie> CreateMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Kingdom of the Planet of the Apes",
                    Duration= 150,
                    Audio = "EN",
                    Category = "C",
                    Rating = 7.3,
                    ReleaseDate = new DateTime(2024, 5, 10),
                    Subtitles = "BG",
                    GenreId = 6,
                    Description = "Several generations in the future following Caesar's reign, apes are now the dominant species and live harmoniously while humans have been reduced to living in the shadows. As a new tyrannical ape leader builds his empire, one young ape undertakes a harrowing journey that will cause him to question all that he has known about the past and to make choices that will define a future for apes and humans alike."
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Fall Guy",
                    Duration= 126,
                    Audio = "EN",
                    Category = "C",
                    Rating = 7.3,
                    ReleaseDate = new DateTime(2024, 4, 26),
                    Subtitles = "BG",
                    GenreId = 1,
                    Description = "Fresh off an almost career-ending accident, stuntman Colt Seavers has to track down a missing movie star, solve a conspiracy and try to win back the love of his life while still doing his day job."
                },
                new Movie
                {
                    Id = 3,
                    Title = "Challengers",
                    Duration= 131,
                    Audio = "EN",
                    Category = "C+",
                    Rating = 7.6,
                    ReleaseDate = new DateTime(2024, 4, 26),
                    Subtitles = "BG",
                    GenreId = 2,
                    Description = "Tennis player turned coach Tashi has taken her husband, Art, and transformed him into a world-famous Grand Slam champion. To jolt him out of his recent losing streak, she signs him up for a 'Challenger' event — close to the lowest level of pro tournament — where he finds himself standing across the net from his former best friend and Tashi's former boyfriend."
                },
                new Movie
                {
                    Id = 4,
                    Title = "Civil War",
                    Duration= 110,
                    Audio = "EN",
                    Category = "D",
                    Rating = 7.5,
                    ReleaseDate = new DateTime(2024, 4, 15),
                    Subtitles = "BG",
                    GenreId = 1,
                    Description = "A journey across a dystopian future America, following a team of military-embedded journalists as they race against time to reach DC before rebel factions descend upon the White House."
                },
                new Movie
                {
                    Id = 5,
                    Title = "Monkey Man",
                    Duration= 122,
                    Audio = "EN",
                    Category = "D",
                    Rating = 7,
                    ReleaseDate = new DateTime(2024, 4, 5),
                    Subtitles = "BG",
                    GenreId = 7,
                    Description = "Kid, an anonymous young man who ekes out a meager living in an underground fight club where, night after night, wearing a gorilla mask, he is beaten bloody by more popular fighters for cash. After years of suppressed rage, Kid discovers a way to infiltrate the enclave of the city’s sinister elite. As his childhood trauma boils over, his mysteriously scarred hands unleash an explosive campaign of retribution to settle the score with the men who took everything from him."
                }
            };

            return movies;
        }
    }
}
