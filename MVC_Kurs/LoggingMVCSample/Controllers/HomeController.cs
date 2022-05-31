using LoggingMVCSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoggingMVCSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Wir rufen die Index-Seite auf");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Wir rufen die Privacy-Seite auf");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}