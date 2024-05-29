namespace CinemaCity.Areas.Admin.Controllers
{
	using Services.Interfaces;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

    using Web.ViewModels.Movie;

    using static Common.WebConstants;

	[Area(AreaName)]
	[Authorize(Roles = AdminRoleName)]
	public class AdminController : Controller
	{
		private readonly ICinemaService _cinemaService;
		private readonly IMovieService _movieService;

		public AdminController(ICinemaService cinemaService, IMovieService movieService)
        {
            _cinemaService = cinemaService;
			_movieService = movieService;
        }

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> AddMovie()
        {
            MovieFormModel model = new MovieFormModel
            {
                Cinemas = await _cinemaService.GetCinemas(),
				Genres = await _movieService.GetGenres(),
				ReleaseDate = DateTime.Now
            };

            return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> AddMovie(MovieFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Cinemas = await _cinemaService.GetCinemas();
				model.Genres = await _movieService.GetGenres();

				return View(model);
			}

			await _movieService.AddMovie(model);

			return RedirectToAction(nameof(Index));
		}
	}
}
