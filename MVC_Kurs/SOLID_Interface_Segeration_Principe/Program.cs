// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region BadCode
public interface IBadVehicle
{
    void ICanFly();
    void ICanDrive();
    void ICanSwim();
}

//Wäre nur hier perfekt verwendbar
public class MulitVehicle : IBadVehicle
{
    public void ICanDrive()
    {
        throw new NotImplementedException();
    }

    public void ICanFly()
    {
        throw new NotImplementedException();
    }

    public void ICanSwim()
    {
        throw new NotImplementedException();
    }
}


public class BadCarVehicle : IBadVehicle
{
    public void ICanDrive()
    {
        //Fahren-> Logik 
    }


    //Implementierung wird nicht beötigt
    public void ICanFly()
    {
        throw new NotImplementedException();
    }

    //Implementierung wird nicht beötigt
    public void ICanSwim()
    {
        throw new NotImplementedException();
    }
}
#endregion

#region Interface aufteilen 
public interface IFlyVehicle
{
    void Fly();
}

public interface IDriveVehicle
{
    void Drive();
}

public interface ISwimVehicle
{
    void Swim();
}



public class MultiVehicle2 : IFlyVehicle, IDriveVehicle, ISwimVehicle
{
    public void Drive()
    {
       //Fahren -> Logik
    }

    public void Fly()
    {
        //Fliegen -> Logik
    }

    public void Swim()
    {
        //Swim -> Logik
    }
}

public class AmphibischeVehicle : ISwimVehicle, IDriveVehicle
{
    public void Drive()
    {
        //Fahren -> Logik
    }

    public void Swim()
    {
        //Swim -> Logik
    }
}

#endregion
