using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreGeneratedApp.Models
{
    public class Movie
    {
        //EF sucht nach einem Id Feld -> Konvention 
        public int Id { get; set; }

        [Required(ErrorMessage = "Titel bitte eingeben")]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Beschreibung bitte eingeben")]
        [MaxLength(100)]
        public string Description { get; set; }

        [Range(0, 99.99)]
        public decimal Price { get; set; }

        [DisplayName("Publish Date")]
        public DateTime PublishedDate { get; set; }

        public int IMDBRating { get; set; }

        public GenreTyp Genre { get; set; }
    }

    public enum GenreTyp { Action, Drama, Comedy, Horror, Animation, ScienceFiction, Documentary }
}
