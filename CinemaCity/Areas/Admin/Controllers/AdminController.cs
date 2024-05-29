namespace CinemaCity.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using static Common.WebConstants;

	[Area(AreaName)]
	[Authorize(Roles = AdminRoleName)]
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
