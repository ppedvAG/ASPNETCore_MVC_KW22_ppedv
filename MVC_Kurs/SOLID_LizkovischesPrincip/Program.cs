IColored coloredFruit = new Kirsche();


((Kirsche)coloredFruit).GetGeschmack();

coloredFruit.GetColor();
coloredFruit.GetGeschmack();

#region BadCode
public class BadKirsche
{
    public int TageDerReife = 100;

    public string GetColor()
    {
        return "rot";
    }
}

public class BadErbeere : BadKirsche
{
    public string GetColor()
    {
        return base.GetColor();
    }
}
#endregion


#region Better

public interface IColored
{
    string GetColor();
}

public enum GeschmackTyp { Süss, Sauer, Bitter }

public interface IGeschmack
{
    GeschmackTyp GetGeschmack();
}


public abstract class Fruits : IColored, IGeschmack
{
    public abstract string GetColor();

    public abstract GeschmackTyp GetGeschmack();

    public virtual void MyVirtualMethod()
    {
        PrivateMethodeInVerbindungMitVirtualenMethoden();
    }

    private void PrivateMethodeInVerbindungMitVirtualenMethoden()
    {

    }
}

public class Kirsche : Fruits
{
    public Kirsche()
    {

    }

    public override string GetColor()
    {
        return "rot";
    }

    public override GeschmackTyp GetGeschmack()
    {
        return GeschmackTyp.Sauer;
    }
}

public class Erbeer : Fruits
{
    public override string GetColor()
    {
        return "rot";
    }

    public override GeschmackTyp GetGeschmack()
    {
        return GeschmackTyp.Sauer;
    }
}
#endregion