using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVCKurs.Configurations;

namespace MVCKurs.Controllers
{
    public class ConfigurationSamplesController : Controller
    {
        //IConfiguration beinhaltet alle Konfigurationen 

        private readonly IConfiguration _configuration; 

        public ConfigurationSamplesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Ausgabe als einfacher String und wir geben jetzt kein HTML aus 
        public ContentResult Sample1()
        {
            //Explizietes auslesen 
            string myKeyValue = _configuration["MyKey"];
            string title = _configuration["Position:Title"];
            string name = _configuration["Position:Name"];
            string loggingValue = _configuration["Logging:LogLevel:Default"];

            return Content($"MyKey value: {myKeyValue} \n" +
                $"Title: {title} \n" +
                $"Name: {name} \n" +
                $"Default Log Level: {loggingValue}");
        }


        /// <summary>
        /// IOptionPatterns -> 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IActionResult Sample2([FromServices] IOptionsSnapshot<GameSettings> gameSettings)
        {
            return View(gameSettings.Value);
        }
    }
}
