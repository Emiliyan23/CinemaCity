namespace CinemaCity.Web.ViewModels.Movie
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Http;

	using Cinema;
    using Genre;
    using Showtime;

    using static Common.EntityConstants;

    public class MovieFormModel
	{
		[MaxLength(MovieTitleMaxLen)]
		[Required(AllowEmptyStrings = false)]
		public string Title { get; set; } = null!;

		[MaxLength(MovieDescriptionMaxLen)]
		[Required(AllowEmptyStrings = false)]
		public string Description { get; set; } = null!;

		[Range(0, 600)]
		[Required]
		public int Duration { get; set; }

		[MaxLength(MovieAudioMaxLen)]
		[Required(AllowEmptyStrings = false)]
		public string Audio { get; set; } = null!;

		[MaxLength(MovieCategoryMaxLen)]
		[Required(AllowEmptyStrings = false)]
		public string Category { get; set; } = null!;

		[Range(0, 10)]
		[Required]
		public double Rating { get; set; }

		[Required]
		public DateTime ReleaseDate { get; set; }

		[MaxLength(MovieSubtitlesMaxLen)]
		[Required(AllowEmptyStrings = false)]
		public string Subtitles { get; set; } = null!;

		[Required]
		public int GenreId { get; set; }

		[Required]
		public IFormFile Photo { get; set; } = null!;

		//public List<ShowtimeFormModel> Showtimes = new List<ShowtimeFormModel>
		//{
		//	new ShowtimeFormModel(),
		//	new ShowtimeFormModel(),
		//	new ShowtimeFormModel()
		//};

		public ShowtimeFormModel Showtime { get; set; } = null!;

        public List<CinemaViewModel> Cinemas { get; set; } = new List<CinemaViewModel>();

		public List<GenreSelectionModel> Genres { get; set; } = new List<GenreSelectionModel>();
	}
}
