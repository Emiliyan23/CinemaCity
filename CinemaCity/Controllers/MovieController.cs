namespace CinemaCity.Controllers
{
    using Web.ViewModels.Movie;
    using Microsoft.AspNetCore.Mvc;

    using Services.Interfaces;

    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
		}

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<MovieViewModel> movies = await _movieService.GetMovies();

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
	        MovieDetailsModel? movie = await _movieService.GetMovieDetails(id);
	        if (movie == null)
	        {
		        return RedirectToAction("All");
	        }

	        return View(movie);
        }
    }
}
