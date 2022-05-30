namespace MVCKurs.Services
{
    public class Car : ICar
    {
        public string Marke { get; set; } = "VW";
        public string Modell { get; set; } = "Polo";
        public int Baujahr { get; set; } = 2000;
    }


    public class Car2
    {
        public string Marke { get; set; } = "VW";
        public string Modell { get; set; } = "TheDirtyPolo";
        public int Baujahr { get; set; } = 1991;
    }
}
