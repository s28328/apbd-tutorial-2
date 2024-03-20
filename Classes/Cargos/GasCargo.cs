namespace Cwiczenie2.Classes.Cargos;

public class GasCargo: Cargo
{
    public GasCargo(string name, double weight) : base(name, weight)
    {
    }

    public GasCargo(GasCargo cargo) : base(cargo)
    {
    }
}