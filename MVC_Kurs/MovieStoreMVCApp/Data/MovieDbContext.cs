using Microsoft.EntityFrameworkCore;
using MovieStoreMVCApp.Models;

namespace MovieStoreMVCApp.Data
{

    //Wenn wir Entity Framework (EFCore) ist die abgeleitete Klasse von DbContext der Grundlage der Datenbankverbindung und
    // Zugriffsmöglichkeiten auf die Tabelle (Tabllen liegen hier als DbSet-Properties vor) 
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base(options)
        {
        }

        //Name der DbSet<Movie> - Property repräsentiert den Tabellennamen in der Datenbank 
        public DbSet<Movie> Movies { get; set; }
    }
}
