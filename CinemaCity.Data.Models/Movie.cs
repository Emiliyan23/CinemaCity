namespace CinemaCity.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityConstants;

    public class Movie
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(MovieTitleMaxLen)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MovieDescriptionMaxLen)]
        public string Description { get; set; } = null!;

        [Required]
        public int Duration { get; set; }

        [Required]
        [MaxLength(MovieAudioMaxLen)]
        public string Audio { get; set; } = null!;

        [Required]
        [MaxLength(MovieCategoryMaxLen)]
        public string Category { get; set; } = null!;

        [Required]
        public float Rating { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        [MaxLength(MovieSubtitlesMaxLen)]
        public string Subtitles { get; set; } = null!;

        [Required]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
