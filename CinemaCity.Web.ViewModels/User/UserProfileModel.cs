namespace CinemaCity.Web.ViewModels.User
{
	using Booking;

	public class UserProfileModel
	{
		public string UserId { get; set; } = null!;

		public string Username { get; set; } = null!;

		public List<BookingViewModel> Bookings { get; set; } = new List<BookingViewModel>();
	}
}
