using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStoreMVCApp.Data;
using MovieStoreMVCApp.Helpers;
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
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            //Default Sortierungsrichtung
            ViewData["TitleSortParam"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";

            ViewData["DescriptionSortParam"] = sortOrder == "Description" ? "description_desc" : "Description";

            ViewData["PriceSortParam"] = sortOrder == "Price" ? "price_desc" : "Price";

            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            List<Movie> movieList = await movieDbContext.Movies.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                movieList = movieList.Where(s => s.Title.Contains(searchString) || s.Description.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "description_desc":
                    movieList = movieList.OrderByDescending(m => m.Description).ToList();
                    break;
                case "Description":
                    movieList = movieList.OrderBy(m => m.Description).ToList();
                    break;
                case "price_desc":
                    movieList = movieList.OrderByDescending(m => m.Price).ToList();
                    break;
                case "Price":
                    movieList = movieList.OrderBy(m => m.Price).ToList();
                    break;
                default:
                    movieList = movieList.OrderBy(m => m.Title).ToList();
                    break;
            }


            int pageSize = 3;


            return View(PaginatedList<Movie>.Create(movieList, pageNumber ?? 1, pageSize));
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            Movie? currentMovie = movieDbContext.Movies.Find(id);

            if (currentMovie == null)
                return NotFound();

            return View(currentMovie);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var currentMovie = movieDbContext.Movies.Find(id);

            if (currentMovie == null)
                return NotFound();

            if (currentMovie.MovieImage != string.Empty)
            {
                var pfad = AppDomain.CurrentDomain.GetData("RootVerzeichnis") + @"\images\" + currentMovie.MovieImage;
            
                FileInfo fi = new FileInfo(pfad);
                
                if (fi.Exists)
                {
                    fi.Delete();
                }

            }
            
            movieDbContext.Movies.Remove(currentMovie);
            movieDbContext.SaveChanges();


            return RedirectToAction("Index");
        }


        [HttpGet] //Zeigen das Formular an
        public IActionResult Create()
        {
            return View();
        }

        //IFormFile -> Paramentervariablennamen 'datei' muss den selben Namen entsprechen, wie name="datei" -> (siehe) <input type="file" name="datei" dirname="C:\" />  
        [HttpPost] //Auswerten des Formular (Hier ist Webserver)
        public IActionResult Create(IFormFile datei, Movie movie) //Parameterbinding  Formular -> wird Objekt 
        {
            //Wenn keine Datei ausgewählt wurde -> würde das ModelState Key->'Datei' als unvalid anzeigen, bedeutet -> ModelState-IsValide = false
            //Da keine DataAnnotation bei Movie.MovieImage vorhanden ist, kann man die Valdierung hier auch rausnehmen
            ModelState.Remove("datei");

            if (movie.Title == "Heidi 3")
            {
                ModelState.AddModelError("Title", $"Der Film {movie.Title} steht auf dem Index"); //ModelState.IsValid -> false

                ModelState.AddModelError("Title", $"Der Film {movie.Title} ist Redundant");
            }

            

            if(ModelState.IsValid)
            {
                //Ganz alte Variante aus dem Naturkundemuseúm
                //string oldSchoolTitle = Request.Form["title"];
                
                
                //Wenn ein Cover ausgewählt wurde, wird dies auch hinterlegt
                //Wenn kein Cover ausgewählt wurde, wird später das Default-Cover verwendet

                if (datei != null)
                {

                    FileInfo fileInfo = new FileInfo(datei.FileName);
                    //Generierter Imagename wird hinterlegt

                    //GUID + ".jpg"
                    movie.MovieImage = Guid.NewGuid().ToString() + fileInfo.Extension;

                    //Festlegen des Zielverzeichnisses
                    var absoluteDestinationFilePath = AppDomain.CurrentDomain.GetData("RootVerzeichnis") + @"\images\" + movie.MovieImage;

                    //Datei wird auf WebServer kopiert -> Upload
                    using (FileStream stream = new FileStream(absoluteDestinationFilePath, FileMode.Create))
                    {
                        datei.CopyTo(stream);
                    }
                }
                
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
