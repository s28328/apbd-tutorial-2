namespace Cwiczenie2.Classes.Cargos;

public abstract class Cargo
{
    protected Cargo(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    protected Cargo(Cargo cargo)
    {
        Name = cargo.Name;
        Weight = cargo.Weight;
    }

    public string Name { get; set; }
    public double Weight { get; set; }

    public string Info()
    {
        return $"Cargo:\n" +
               $"Name:{Name}\n" +
               $"Weight:{Weight} (kg)";
    }
    
}