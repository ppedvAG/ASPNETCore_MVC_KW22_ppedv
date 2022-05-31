using Microsoft.AspNetCore.Mvc;
using MVCKurs.Services;

namespace MVCKurs.Controllers
{
    //Bei´einem Request passiert folgendes: 

    //Controller-Klasse wird bei jedem Request neu erstellt (Factory-Pattern) -> Also eine neue Instanz
    //Auf Konstruktors 
    //Die jeweilige Action wird aufgerufen 
    public class DependencyInjectionsController : Controller
    {
        private readonly ICar car;


        //Konstruktor - Injection -> GetRequiredService
        //ctor + tab + tab  
        public DependencyInjectionsController(ICar car, IDateTimeService dateTimeService) //Wir greifen auf den IOC Container zu und erhalten eine Instanz von Car -> Intern wird ServiceProvider.GetRequiredService aufgerufen 
        {
            this.car = car;

            //Ist nicht Ideale Weg, aber machbar. 
            //dateTimeService = new DateTimeService(new DateTime(1999, 5, 5));
            //dateTimeService.CurrentDateTime = new DateTime(1999, 5, 5);
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

        //Expliziet für eine Action-Methode verwenden wir [FromServices] 
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
