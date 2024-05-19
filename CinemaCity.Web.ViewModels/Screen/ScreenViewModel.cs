namespace CinemaCity.Web.ViewModels.Screen
{
    using Showtime;

    public class ScreenViewModel
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public List<ShowtimeViewModel> Showtimes { get; set; } = new List<ShowtimeViewModel>();
    }
}
