//Hello IOC Container

using Microsoft.Extensions.DependencyInjection;

//ServiceCollection wird verwendet um Dienste oder weniger Object vor dem AppStart der Application hinzuzufügen.
IServiceCollection serviceCollection = new ServiceCollection();

//Als ShowCase fügen wir unsere ICar / DummyCar hinzu
serviceCollection.AddSingleton<ICar, DummyCar>(); //Objekt wird nur 1x instanziiert -> Singleton - Pattern

//Was wäre, wenn weitere Implementierung mit selben Interface?

//serviceCollection.AddSingleton<ICar, DummyCar2>(); 

//Unterschied zwischen Singleton / Scoped / Transient?
//serviceCollection.AddScoped<ICar, DummyCar2>();
//serviceCollection.AddTransient<ICar, DummyCar>();


//serviceCollection.BuildServiceProvider(); -> Initialisierung wird mit BuildServiceProvider beendet 
ServiceProvider provider = serviceCollection.BuildServiceProvider();

//Mithilfe des ServiceProvider können wir auf den IOC-Container zugreifen

//Objekt Ahoi
ICar myDummyCar = provider.GetRequiredService<ICar>();

ICar? myDummyCar2 = provider.GetService<ICar>();

//Unterschied zwischen GetRequiredService und GetService:
//Im Fehlerfall, wenn zu ICar kein Objekt gefunden wurde, gibt GetService NULL zurück und GetRequiredService eine Exception

public interface ICar
{
    string Marke { get; set; }
    string Modell { get; set; }
    int Baujahr { get; set; }
}

public class DummyCar : ICar
{
    public string Marke { get; set; } = "VW";
    public string Modell { get; set; } = "Polo";
    public int Baujahr { get; set; } = 2000;
}

public class DummyCar2 : ICar
{
    public string Marke { get; set; } = "BMW";
    public string Modell { get; set; } = "Z4";
    public int Baujahr { get; set; } = 2021;
}