namespace CinemaCity.Services.Interfaces
{
    using Web.ViewModels.Movie;

    public interface IMovieService
    {
        Task<List<MovieViewModel>> GetMovies();

        Task<MovieDetailsModel?> GetMovieDetails(int movieId);
    }
}
