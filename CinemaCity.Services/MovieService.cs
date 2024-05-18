namespace CinemaCity.Services
{
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Web.Infrastructure;
    using Web.ViewModels;

    public class MovieService : IMovieService
    {
	    private readonly string _movieImagesFolderPath;
        private readonly CinemaCityContext _context;

        public MovieService(IOptions<MovieSettings> movieSettings, CinemaCityContext context)
        {
            _context = context;
            _movieImagesFolderPath = movieSettings.Value.ImagesFolderPath;
        }

        public async Task<List<MovieViewModel>> GetMovies()
        {
            var movies = await _context.Movies
                .Where(m => m.ReleaseDate >= DateTime.Now.AddMonths(-2))
                .OrderByDescending(m => m.ReleaseDate)
                .AsNoTracking()
                .ToListAsync();

            List<MovieViewModel> movieModels = movies
	            .Select(m => new MovieViewModel
	            {
		            Id = m.Id,
		            Title = m.Title,
		            ImagePath = GetMovieImagePath(m.Id)
	            }).ToList();

            return movieModels;
        }

        private string GetMovieImagePath(int movieId)
        {
            string imageFileName = $"{movieId}.jpg";
            string imagePath = Path.Combine(_movieImagesFolderPath, imageFileName);

            if (File.Exists(imagePath))
            {
                return $"/images/movies/{imageFileName}";
            }

            return "/images/movies/placeholder.jpg";
        }
    }
}
