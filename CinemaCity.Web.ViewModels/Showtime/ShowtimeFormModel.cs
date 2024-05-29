namespace CinemaCity.Web.ViewModels.Showtime
{
	public class ShowtimeFormModel
	{
		public DateTime StartTime { get; set; } = DateTime.Now;

		public int CinemaId { get; set; } = 0;

		public int MovieId { get; set; } = 0;
	}
}
