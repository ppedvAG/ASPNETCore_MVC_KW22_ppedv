using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStoreMVCApp.Data;
using MovieStoreMVCApp.Models;

namespace MovieStoreMVCApp.Controllers
{
    public class MovieStoreController : Controller
    {
        private readonly MovieDbContext movieDbContext;

        public MovieStoreController(MovieDbContext dbContext)
        {
            movieDbContext = dbContext;
        }

        //Übersicht aller Filme 
        //Was ist eine Get-Methode? Browser sende Anfrage an den WebServer (GET-Methode) und als Ergebnis wird eine HTML-Seite zurückgesendet
        [HttpGet]
        public IActionResult Index()
        {
            return View(movieDbContext.Movies.ToList());
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            Movie? currentMovie = movieDbContext.Movies.Find(id);

            if (currentMovie == null)
                return NotFound();

            return View(currentMovie);
        }


        [HttpGet] //Zeigen das Formular an
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //Auswerten des Formular (Hier ist Webserver)
        public IActionResult Create(Movie movie) //Parameterbinding  Formular -> wird Objekt 
        {

            if (movie.Title == "Heidi 3")
            {
                ModelState.AddModelError("Title", $"Der Film {movie.Title} steht auf dem Index"); //ModelState.IsValid -> false

                ModelState.AddModelError("Title", $"Der Film {movie.Title} ist Redundant");
            }

            if(ModelState.IsValid)
            {
                //Ganz alte Variante aus dem Naturkundemuseúm
                //string oldSchoolTitle = Request.Form["title"];
                movieDbContext.Movies.Add(movie);

                movieDbContext.SaveChanges();

                return RedirectToAction("Index"); //Wir rufen hier die Get-Methode Index auf
            }
            
            return View(movie); //Ausgefülltes Formular bekommt Fehlermeldung angezeigt
        }


       

        [HttpPost] //Auswerten des Formular (Hier ist Webserver)
        public IActionResult CreateWithRedundanzCheck(Movie movie) //Parameterbinding  Formular -> wird Objekt 
        {
            //Prüfung

            //Manuelle Validierung-Regel

            //Hinzufügen

            return RedirectToAction("Index");
        }
    }
}
