namespace GeoRelationsSample.Models
{
    public class Continent
    {
        public int Id { get; set; } 
        public string Name { get;set; }

        //1:N : Continent -> mehrere Länder 

        #region Navigation Relation 1:N
        public virtual ICollection<Country> Countries { get; set; }
        #endregion
    }
}
