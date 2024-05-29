namespace CinemaCity.Services.Interfaces
{
	using Web.ViewModels.User;

	public interface IUserService
	{
		Task<UserProfileModel> GetUserProfile(string userId);

		Task<bool> UserExistsById(string userId);
	}
}
