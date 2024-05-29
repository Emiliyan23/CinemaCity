namespace CinemaCity.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    using Data;
    using Data.Models;
    using Interfaces;
	using Web.Infrastructure;
    using Web.ViewModels.Cinema;
    using Web.ViewModels.Genre;
    using Web.ViewModels.Movie;
	using Web.ViewModels.Showtime;

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

		/// <summary>
		/// Asynchronously finds and returns details for a movie given an id.
		/// </summary>
		/// <param name="movieId"></param>
		/// <returns>MovieDetailsModel for displaying. If the id doesn't exist, returns null.</returns>
		public async Task<MovieDetailsModel?> GetMovieDetails(int movieId)
        {
	        var movie = await _context.Movies
		        .Include(movie => movie.Genre)
		        .AsNoTracking()
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
		        ImagePath = GetMovieImagePath(movieId),
                Cinemas = _context.Showtimes
                    .Where(s => s.MovieId == movie.Id)
                    .GroupBy(s => s.Cinema)
                    .Select(g => new CinemaViewModel
                    {
                        Id = g.Key.Id,
                        Name = g.Key.CinemaName,
                        Location = g.Key.Location,
                        Showtimes = g.Select(st => new ShowtimeViewModel
                        {
                            Id = st.Id,
                            StartTime = st.StartTime
                        }).ToList()
                    }).ToList()
            };

	        return movieDetails;
        }

        public async Task<string> GetMovieTitle(int movieId)
        {
	        var title = await _context.Movies
		        .Where(m => m.Id == movieId)
		        .Select(m => m.Title)
		        .AsNoTracking()
		        .SingleOrDefaultAsync();

	        return title!;
        }

        /// <summary>
        /// Checks if a showtime exists in the database by its id.
        /// </summary>
        /// <param name="showtimeId">The id of the showtime to check.</param>
        /// <returns>True if the showtime exists, false otherwise.</returns>
		public async Task<bool> ShowtimeExistsById(int showtimeId)
        {
	        bool exists = await _context.Showtimes
		        .AnyAsync(s => s.Id == showtimeId);

            return exists;
        }

        public async Task AddMovie(MovieFormModel model)
        {
	        Movie movie = new Movie
	        {
		        Title = model.Title,
		        Description = model.Description,
		        Duration = model.Duration,
		        Audio = model.Audio,
		        Category = model.Category,
		        Rating = model.Rating,
		        ReleaseDate = model.ReleaseDate,
		        Subtitles = model.Subtitles,
		        GenreId = model.GenreId
	        };
			await _context.Movies.AddAsync(movie);
			await _context.SaveChangesAsync();

            Showtime showtime = new Showtime
			{
				CinemaId = model.Showtime.CinemaId,
				MovieId = movie.Id,
				StartTime = model.Showtime.StartTime
			};

	        await _context.Showtimes.AddAsync(showtime);
            await _context.SaveChangesAsync();

            if (model.Photo != null && model.Photo.Length > 0)
            {
	            string fileName = $"{movie.Id}.jpg";

				await using (var stream = new FileStream(Path.Combine(_movieImagesFolderPath, fileName), FileMode.Create))
	            {
		            await model.Photo.CopyToAsync(stream);
	            }
            }
		}

        public async Task<List<GenreSelectionModel>> GetGenres()
        {
	        var genres = await _context.Genres
		        .Select(g => new GenreSelectionModel
		        {
			        Id = g.Id,
			        Name = g.Name
		        })
		        .ToListAsync();

            return genres;
        }

        public async Task<int> GetMovieIdByShowTimeId(int showtimeId)
        {
	        int movieId = await _context.Showtimes
		        .Where(s => s.Id == showtimeId)
		        .AsNoTracking()
				.Select(s => s.MovieId)
		        .SingleOrDefaultAsync();

			return movieId;
        }

        public string GetMovieImagePath(int movieId)
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
