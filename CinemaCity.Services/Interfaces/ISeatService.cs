namespace CinemaCity.Services.Interfaces
{
	public interface ISeatService
	{
		Task<int> GetSeatId(int row, int col);
	}
}
