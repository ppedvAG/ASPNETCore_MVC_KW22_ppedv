// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region Sehr schlechte Variante
public class BadEmployee
{
    //Kann mit der Zeit sein, dass diese Klasse über 1000 Zeilen verfügt 


    //Model -> Datenstruktur
    public int Id { get; set; } 
    public string Name { get; set; }

    //DataAccessLayer -> Repository 
    public void InsertEmployeeToTable(BadEmployee badEmployee)
    {
        //... Speicher den Datensatz in eine Tabelle
    }

    //Presentation-Layer (UI) oder Service Layer
    public void GenerateReport()
    {
        //Erstellen wir einen Report
    }
}
#endregion

#region Bessere Variante
//Achtung jede Klasse steht in der Praxis meist in einer Datei
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class EmployeeRepository
{
    private string Properties { get; set; }

    public void Insert(Employee employee)
    {
        //Datensatz wird eingefügt
    }

    // public List<Employee> GetAll();
    //public Employe GetById(int id);
}


public class GenerateReport
{
    public void Generate()
    {

    }
}

#endregion


