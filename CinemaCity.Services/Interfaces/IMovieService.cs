namespace CinemaCity.Services.Interfaces
{
    using Web.ViewModels.Movie;

    public interface IMovieService
    {
        Task<List<MovieViewModel>> GetMovies();

        Task<MovieDetailsModel?> GetMovieDetails(int movieId);

        Task<string> GetMovieTitle(int movieId);

        Task<bool> ShowtimeExistsById(int showtimeId);

        public string GetMovieImagePath(int movieId);
    }
}
