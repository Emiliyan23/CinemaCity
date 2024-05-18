namespace CinemaCity.Web.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? ImagePath { get; set; }
    }
}
