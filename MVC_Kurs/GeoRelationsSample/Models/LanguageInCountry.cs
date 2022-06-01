using System.ComponentModel.DataAnnotations;

namespace GeoRelationsSample.Models
{
    public class LanguageInCountry
    {
        public int Id { get; set; } 

        [Range(1, 100)]
        public int Percent { get; set; }

        public int CountryId { get; set; }
        public int LanguageId { get; set; } 

        #region Navigation
        public virtual Country CountryRef { get; set; }
        public virtual Language LanguageRef { get; set; }
        #endregion
    }
}
