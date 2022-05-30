using Microsoft.AspNetCore.Mvc;
using MVCKurs.Services;

namespace MVCKurs.Controllers
{
    //
    //Controller-Klasse wird bei jedem Request neu erstellt (Factory-Pattern)
    public class DependencyInjectionsController : Controller
    {
        private readonly ICar car;


        //Konstruktor - Injection
        //ctor + tab + tab 
        public DependencyInjectionsController(ICar car) //Wir greifen auf den IOC Container zu und erhalten eine Instanz von Car -> Intern wird ServiceProvider.GetRequiredService aufgerufen 
        {
            this.car = car;
        }

        //public DependencyInjectionsController(ICar car, Car2 onlyObject) //Wir greifen auf den IOC Container zu und erhalten eine Instanz von Car -> Intern wird ServiceProvider.GetRequiredService aufgerufen 
        //{
        //    this.car = car;
        //}

        //Wenn ich https://localhost:12345/DependencyInjections -> https://localhost:12345/DependencyInjections/Index 

        //Bevor wir die Methode Index aufrufen, wird bei jedem Request, die Klasse DependencyInjectionsController neu instaziiert 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2([FromServices] ICar carOnlyForThisActionMethode)
        {
            return View();
        }

        public IActionResult Index3()
        {

            //Zugriff via HttpContext -> Variant1 
            ICar? car = this.HttpContext.RequestServices.GetService<ICar>();


            //Zugriff via HttpContext -> Variant2
            ICar car1 = this.HttpContext.RequestServices.GetRequiredService<ICar>();

            return View();
        }
    }
}
