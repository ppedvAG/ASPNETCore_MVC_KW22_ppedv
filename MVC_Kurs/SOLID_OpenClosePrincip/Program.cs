// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//POCO - Klasse (wird in EF verwendet)
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    //Keine Logik soll vorhanden sein 
}

public class BadReportGenerator
{
    public string ReportType { get; set; } = string.Empty;

    //weiteres Problem
    public string SelectedTemplate { get; set; }

    public void GenerateReport(Employee employee)
    {
        if (ReportType == "CR")
        {
            //Dritanbieter CrystalReports -> DLL 

            //500 Zeilen
        }
        else if(ReportType == "ListLabel")
        {
            //Dritanbieter List & Label -> DLL 

            // 500 Zeilen
        }
        else if(ReportType == "PDF")
        {
            //PDF Dll Anbindung 

            //200 Zeilen
        }
    }
}

#region bessere variante

//Open-Part
public abstract class ReportGenerator
{
    public abstract string SelectedTemplate { get; set; }

    public abstract void GenerateReport(Employee em);   //abstrakte Methoden müssen überschrieben werden

    public void SendePing(string IpAdress)
    { 
        //Allgemeine Logik, die überall gleich ist
    }

    public virtual void SendePingBase(string IpAdress)
    {
        //Basis-Logik
    }
}


//Close-Part
public class PDFReportGenerator : ReportGenerator
{
    public override string SelectedTemplate { get; set; } //Validierung Möglich im Setter -> Ist es ein PDF-Template
   

    //Alle Variablen betreffen PDF 
    public override void GenerateReport(Employee em)
    {
        //any Code

        SendePing("127.0.0.1");
        SendePingBase("127.0.0.1");
    }

    public override void SendePingBase(string IpAdress)
    {
        base.SendePingBase(IpAdress);
        //Sepzieller Code
    }
    //Compress Rate 
    //Watermarks
}


//Close-Part
public class CrystalReports : ReportGenerator
{
    public override string SelectedTemplate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override void GenerateReport(Employee em)
    {

    }

    //Template Vorlagen
    //Template Ausgabe-Verzeichnis
}


public class MyApp
{
    public void Export(Employee employee, string generatorType)
    {
        if ()
    }
}

#endregion