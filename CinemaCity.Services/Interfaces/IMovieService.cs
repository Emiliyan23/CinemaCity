namespace CinemaCity.Services.Interfaces
{
    using Web.ViewModels;

    public interface IMovieService
    {
        Task<List<MovieViewModel>> GetMovies();

    }
}
