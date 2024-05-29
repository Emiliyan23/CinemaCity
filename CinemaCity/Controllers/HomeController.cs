using CinemaCity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using static CinemaCity.Common.WebConstants;

namespace CinemaCity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
	        if (User.IsInRole(AdminRoleName))
	        {
		        return RedirectToAction("Index", "Admin", new { area = AreaName });
	        }
			return RedirectToAction("All", "Movie");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
