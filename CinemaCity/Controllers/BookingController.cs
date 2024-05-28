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

		    BookingFormModel model = new BookingFormModel
		    {
			    UserId = User.Id()!,
			    ShowtimeId = id,
			    TicketTypes = await _bookingService.GetTicketTypes(),
			    ImagePath = _movieService.GetMovieImagePath(id),
			    MovieTitle = await _movieService.GetMovieTitle(id),
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

		    if (!ModelState.IsValid)
		    {
			    model.TicketTypes = await _bookingService.GetTicketTypes();
			    return View(model);
		    }

		    return RedirectToAction("All", "Movie");
	    }
    }
}
