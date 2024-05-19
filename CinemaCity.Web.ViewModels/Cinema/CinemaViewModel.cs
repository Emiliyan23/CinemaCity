namespace CinemaCity.Web.ViewModels.Cinema
{
    using Showtime;

    public class CinemaViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public List<ShowtimeViewModel> Showtimes { get; set; } = new List<ShowtimeViewModel>();
    }
}
