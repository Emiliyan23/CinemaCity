﻿namespace CinemaCity.Services
{
    using Web.ViewModels.Movie;
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Web.Infrastructure;

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

        public async Task<MovieDetailsModel?> GetMovieDetails(int movieId)
        {
	        var movie = await _context.Movies
		        .Include(movie => movie.Genre)
		        .FirstOrDefaultAsync(m => m.Id == movieId);

	        if (movie == null)
	        {
		        return null;
			}

			MovieDetailsModel movieDetails = new MovieDetailsModel
	        {
		        Id = movie.Id,
		        Title = movie.Title,
		        Audio = movie.Audio,
		        Category = movie.Category,
		        Description = movie.Description,
		        Duration = movie.Duration,
		        Genre = movie.Genre.Name,
		        Rating = movie.Rating,
		        Subtitles = movie.Subtitles,
		        ImagePath = GetMovieImagePath(movieId)
	        };

	        return movieDetails;
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