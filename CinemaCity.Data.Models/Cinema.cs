namespace CinemaCity.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityConstants;

    public class Cinema
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(CinemaNameMaxLen)]
        public string CinemaName { get; set; } = null!;

        [Required]
        [MaxLength(CinemaLocationMaxLen)]
        public string Location { get; set; } = null!;

        public ICollection<Screen> Screens { get; set; } = new List<Screen>();
    }
}
