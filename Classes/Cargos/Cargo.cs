namespace Cwiczenie2.Classes.Cargos;

public abstract class Cargo
{
    protected Cargo(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string Name { get; set; }
    public double Weight { get; set; }
    
}