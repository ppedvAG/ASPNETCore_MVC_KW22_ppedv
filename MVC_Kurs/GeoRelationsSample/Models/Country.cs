namespace GeoRelationsSample.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Population { get; set; }
        public string Capital { get; set; }

        public int ContinentId { get; set; }

        #region Navigation
        public virtual Continent ContinentRef { get; set; }

        public virtual ICollection<LanguageInCountry> CountryLanguages { get; set; }
        #endregion

    }
}
