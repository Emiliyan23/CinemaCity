namespace CinemaCity.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Services.Interfaces;
	using Web.ViewModels.User;

	[Authorize]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> Profile(string id)
		{
			if (await _userService.UserExistsById(id) == false)
			{
				return RedirectToAction("All", "Movie");
			}

			UserProfileModel model = await _userService.GetUserProfile(id);

			return View(model);
		}
	}
}
