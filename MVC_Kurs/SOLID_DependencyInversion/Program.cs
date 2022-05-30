// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


ICar dummyCar = new DummyCar();

//2 tage Testen

ICarService carService = new CarService();
carService.Repair(dummyCar);

//Wenn alles fertig ist
ICar produktivesCarObjekt = new Car();
produktivesCarObjekt.Marke = "Mercedes";
produktivesCarObjekt.Modell = "Silberpfeil";

carService.Repair(produktivesCarObjekt);

#region Feste Kopplung bringt Nachteile mit sich

//Programmierer A: 5 Tage -> (fängt an Tag 1 an und ist an Tag 5 fertig)
public class BadCar
{
    public string Marke { get; set; }
    public string Modell { get; set; }
    public int Baujahr { get; set; }
}

//Programmierer B: 3 Tage -> (fängt an Tag 5oder6 an und ist an Tag 8/9 fertig)
public class BadCarService
{
    public void Repair(BadCar car) //Feste Kopplung -> Die Klasse BadCarService kennt die Klasse BadCar
    {
        //repariere Auto
    }
}

#endregion

#region Lose Kopplung 
// - Paralleles Arbeiten 

public interface ICar
{
    string Marke { get; set; }
    string Modell { get; set; }
    int Baujahr { get; set; }
}

public interface ICarVersion2 : ICar
{
    string Farbe { get; set; }
}

public interface ICarService
{
    void Repair(ICar car); //Lose Kopplung 
    void Repair(ICarVersion2 car);
}

//Programmierer A: 5 Tage -> Startet Tag 1 bis Tag 5
public class Car : ICar
{
    public string Marke { get; set; }
    public string Modell { get; set; }
    public int Baujahr { get; set; }
}


//Programmierer B: 3 Tage -> Startet Tag 1 bis Tag 3
public class CarService : ICarService
{
    public void Repair(ICar car)
    {
        //repariere Auto
        
    }
}

//Programmierer B kann 2 Tage 'Testen'

public class DummyCar : ICar
{
    public string Marke { get; set; } = "VW";
    public string Modell { get; set; } = "Polo";
    public int Baujahr { get; set; } = 2000;

}

#endregion