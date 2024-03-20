namespace Cwiczenie2.Classes.Cargos;

class LiquidCargo : Cargo
{
    public bool IsHazard { get; set; }

    public LiquidCargo(string name, double weight, bool isHazard) : base(name, weight)
    {
        IsHazard = isHazard;
    }

    public LiquidCargo(LiquidCargo cargo) : base(cargo)
    {
        IsHazard = cargo.IsHazard;
    }
}