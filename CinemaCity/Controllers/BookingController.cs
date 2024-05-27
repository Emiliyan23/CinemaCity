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

	    public BookingController(IBookingService bookingService)
	    {
		    _bookingService = bookingService;
	    }

        [HttpGet]
        public async Task<IActionResult> SelectTickets(int id)
        {
	        BookingFormModel model = new BookingFormModel
	        {
		        UserId = User.Id()!,
                Tickets = await _bookingService.GetTicketTypes()
	        };

            return View(model);
        }
    }
}
