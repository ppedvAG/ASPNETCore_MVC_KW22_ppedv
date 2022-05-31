namespace MovieStoreMVCApp.Data
{
    public static class DataSeeder
    {
        public static void SeedMovieStoreDb(MovieDbContext context)
        {
            //Wenn keine Datensätze vorhanden sind, werden Testdaten hinzugefügt
            if (!context.Movies.Any())
            {
                context.Movies.Add(new Models.Movie { Title = "Coda", Description = "Singtalent", Price = 12.99m, Genre = Models.GenreTyp.Drama, PublishedDate = new DateTime(2021, 11, 11) });
                context.Movies.Add(new Models.Movie { Title = "King Richard", Description = "Serna und Venus Williams", Price = 18.99m, Genre = Models.GenreTyp.Documentary, PublishedDate = new DateTime(2021, 10, 10) });
                
                //Unit OF Work - Pattern wird hier angewendet 
                context.SaveChanges();
            }
        }
    }
}
