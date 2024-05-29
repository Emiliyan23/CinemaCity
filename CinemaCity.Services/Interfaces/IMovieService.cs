namespace CinemaCity.Services.Interfaces
{
	using Web.ViewModels.Genre;
	using Web.ViewModels.Movie;

    public interface IMovieService
    {
        Task<List<MovieViewModel>> GetMovies();

        Task<MovieDetailsModel?> GetMovieDetails(int movieId);

        Task<string> GetMovieTitle(int movieId);

        Task<bool> ShowtimeExistsById(int showtimeId);

        Task AddMovie(MovieFormModel model);

        Task<List<GenreSelectionModel>> GetGenres();

        Task<int> GetMovieIdByShowTimeId(int showtimeId);

        public string GetMovieImagePath(int movieId);
    }
}
