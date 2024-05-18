namespace CinemaCity.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityConstants;

    public class Genre
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLen)]
        public string Name { get; set; } = null!;

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
