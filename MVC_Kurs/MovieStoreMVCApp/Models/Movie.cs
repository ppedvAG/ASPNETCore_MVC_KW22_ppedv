using System.ComponentModel; //Anzeigevarianten 
using System.ComponentModel.DataAnnotations; //Validierungen (Auswirkung auf UI + DB-Rollout)
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreMVCApp.Models
{
    //In einem Monolith -> Model-Verzeichnis -> Repräsentiert eine Tabelle in der Datenbank
    public class Movie
    {
        //EF sucht nach einem Id Feld -> Konvention 
        public int Id { get; set; }

        [Required(ErrorMessage = "Titel bitte eingeben")]
        [MaxLength(20)] 
        public string Title { get; set; }

        [Required (ErrorMessage= "Beschreibung bitte eingeben")]
        [MaxLength(100)]
        public string Description { get;set; }



        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } 

        [DisplayName("Publish Date")]
        public DateTime PublishedDate { get; set; }

        
        public int IMDBRating { get; set; }

        public string MovieImage { get; set; } = string.Empty;

        public GenreTyp Genre { get; set; }
    }

    public enum GenreTyp { Action, Drama, Comedy, Horror, Animation, ScienceFiction, Documentary}
}
