namespace CinemaCity.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Interfaces;
    using Web.Infrastructure.Extensions;
    using Web.ViewModels.Booking;

    [Authorize]
    public class BookingController : Controller
    {
	    private readonly IBookingService _bookingService;
	    private readonly IMovieService _movieService;

	    public BookingController(IBookingService bookingService, IMovieService movieService)
	    {
		    _bookingService = bookingService;
		    _movieService = movieService;
	    }

	    [HttpGet]
	    public async Task<IActionResult> SelectTickets(int id)
	    {
		    if (!await _movieService.ShowtimeExistsById(id))
		    {
			    return RedirectToAction("All", "Movie");
		    }

		    int movieId = await _movieService.GetMovieIdByShowTimeId(id);

			BookingFormModel model = new BookingFormModel
		    {
			    ShowtimeId = id,
			    TicketTypes = await _bookingService.GetTicketTypes(),
			    ImagePath = _movieService.GetMovieImagePath(movieId),
			    MovieTitle = await _movieService.GetMovieTitle(movieId),
				TakenSeats = await _bookingService.GetAllTakenSeats(id)
		    };

		    return View(model);
	    }

	    [HttpPost]
	    public async Task<IActionResult> SelectTickets(BookingFormModel model)
	    {
		    if (model.SelectedTickets.SelectedTickets.All(t => t.Quantity == 0))
		    {
			    ModelState.AddModelError("SelectedTicketTypes", "Please select at least one ticket.");
		    }

			await _bookingService.AddBooking(model, User.Id()!);
		    return RedirectToAction("All", "Movie");
	    }
    }
}
