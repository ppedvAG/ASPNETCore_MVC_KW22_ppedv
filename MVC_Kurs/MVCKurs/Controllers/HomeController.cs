using Microsoft.AspNetCore.Mvc;
using MVCKurs.Models;
using System.Diagnostics;

namespace MVCKurs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //UI zu Index ist Views\Home\Index.cshtml
        public IActionResult Index()
        {
            return View(); // Index.cshtml als HTML-Snippet

            /*
             *  The following locations were searched:
                /Views/Home/Index.cshtml
                /Views/Shared/Index.cshtml
             * 
             */
        }

        //UI zu Index ist Views\Home\Privacy.cshtml
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}