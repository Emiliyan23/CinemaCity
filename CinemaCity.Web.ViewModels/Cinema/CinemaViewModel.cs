namespace CinemaCity.Web.ViewModels.Cinema
{
    using Screen;

    public class CinemaViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public List<ScreenViewModel> Screens { get; set; } = new List<ScreenViewModel>();
    }
}
