namespace CinemaCity.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Interfaces;
    using Web.ViewModels;

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
    }
}
