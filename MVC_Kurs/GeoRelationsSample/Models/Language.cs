namespace GeoRelationsSample.Models
{
    public class Language
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        #region Navigation
        public virtual ICollection<LanguageInCountry> LanguageInCountries { get; set; }
        #endregion
    }
}
