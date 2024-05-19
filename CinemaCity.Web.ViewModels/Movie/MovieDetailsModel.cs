namespace CinemaCity.Web.ViewModels.Movie
{
    using Cinema;

    public class MovieDetailsModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string Description { get; set; } = null!;

		public int Duration { get; set; }

		public string Audio { get; set; } = null!;

		public string Category { get; set; } = null!;

		public double Rating { get; set; }

		public string Subtitles { get; set; } = null!;

		public string Genre { get; set; } = null!;

		public string ImagePath { get; set; } = null!;

        public List<CinemaViewModel> Cinemas { get; set; } = new List<CinemaViewModel>();
    }
}
