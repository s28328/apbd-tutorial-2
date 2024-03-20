namespace Cwiczenie2.Classes.Cargos;

public class RefrigeratedCargo:Cargo
{
    public string TypeOfCargo { get; set; }
    public double Temperature { get; set; }

    public RefrigeratedCargo(string name, double weight, string typeOfCargo, double temperature) : base(name, weight)
    {
        TypeOfCargo = typeOfCargo;
        Temperature = temperature;
    }

    public RefrigeratedCargo(RefrigeratedCargo cargo) : base(cargo)
    {
        TypeOfCargo = cargo.TypeOfCargo;
        Temperature = cargo.Temperature;
    }
}