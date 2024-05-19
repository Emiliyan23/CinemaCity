namespace CinemaCity.Web.ViewModels.Showtime
{
    public class ShowtimeViewModel
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public string ScreenType { get; set; } = null!;
    }
}
