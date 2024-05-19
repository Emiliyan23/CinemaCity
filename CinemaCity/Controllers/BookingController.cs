namespace CinemaCity.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BookingController : Controller
    {
        [HttpGet]
        public IActionResult SelectTickets(int id)
        {
            return View();
        }
    }
}
