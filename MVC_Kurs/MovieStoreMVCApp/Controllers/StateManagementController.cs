using Microsoft.AspNetCore.Mvc;
using MovieStoreMVCApp.Models;
using System.Text.Json;
using MovieStoreMVCApp.Helpers;

namespace MovieStoreMVCApp.Controllers
{
    public class StateManagementController : Controller
    {
        
        public IActionResult ViewDataSample()
        {
            //Hilfsdaten
            ViewData["abc"] = "Hallo liebe Teilnehmer";
            ViewData["def"] = "Ich hoffe der Kurs gefällt euch";

            return View();
        }

        
        [HttpGet("/StateManagement/ViewBagSample")]
        public IActionResult ViewBagSample()
        {
            ViewBag.ABC = "Hallo liebe Teilnehmer";
            ViewBag.DEF = "Ich hoffe Ihr habt viel gelernt";

            return View();
        }


        [HttpGet("/StateManagement/TempDataFirstSample")]
        public IActionResult TempDataFirstSample()
        {
            TempData["EmailAdresse"] = "KevinW@ppedv.de";
            TempData["Id"] = 123;
            return View();
        }

        [HttpGet("/StateManagement/TempDataSecondSample")]
        public IActionResult TempDataSecondSample()
        {

            return View();
        }

        [HttpGet("/StateManagement/TempDataSecondSample/{id}")]
        public IActionResult TempDataThirdSample(int id)
        {

            return View();
        }

        public IActionResult SessionInitalize()
        {
            HttpContext.Session.SetInt32("Lottozahlen", 1234567);
            HttpContext.Session.SetString("Lottogewinner", "Otto Walkes");


            Movie movie = new() { Id = 123, Title = "Jurassic Park", Description = "TRex wird Veggie", Price = 9.99m, Genre = GenreTyp.Comedy, IMDBRating = 1 };
            string jsonString = JsonSerializer.Serialize(movie);

            HttpContext.Session.SetString("MovieObj", jsonString);

            return View();
        }

        public IActionResult SessionAccess()
        {
            int? lottozahlen = HttpContext.Session.GetInt32("Lottozahlen");

            string lottogewinner = HttpContext.Session.GetString("Lottogewinner");


            string jsonString = HttpContext.Session.GetString("MovieObj");
            Movie movie = JsonSerializer.Deserialize<Movie>(jsonString);

            return View();
        }
    }
}
