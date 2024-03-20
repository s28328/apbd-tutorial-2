using Cwiczenie2.Classes.Cargos;
using Cwiczenie2.Interfaces;

namespace Cwiczenie2.Classes;

public class RefrigeratedContainer : Container, ILoadable
{
    
    public string TypeOfCargo { get; set; }
    public double Temperature { get; set; }
    
    
    public RefrigeratedContainer(
        double heightInCm,
        double tareWeightInKg,
        double depthInCm,
        double maxPayloadInKg) : base(heightInCm, tareWeightInKg, depthInCm, maxPayloadInKg)
    {
    }

    public Cargo? Unload()
    {
        if (Cargo == null)
        {
            Console.WriteLine("Container has no cargo to unload.");
            return null;
        }
        this.MassOfCargoInKg = 0;
        var unloadedCargo = new RefrigeratedCargo((RefrigeratedCargo)this.Cargo);
        this.Cargo = null;
        return unloadedCargo;
    }

    public void Load(Cargo cargo)
    {
        if (cargo.GetType().Name != "RefrigeratedCargo")
            throw new ArgumentException("Not valid type of cargo to load.");
        var refrigeratedCargo = (RefrigeratedCargo)cargo;
        if (refrigeratedCargo.TypeOfCargo != TypeOfCargo || this.Temperature < refrigeratedCargo.Temperature)
        {
            Console.WriteLine("Type or temperature of cargo is not compatible with container.");
            Console.WriteLine("Cargo will not be loaded");
        }
        else
        {
            this.Cargo = refrigeratedCargo;
            this.MassOfCargoInKg = refrigeratedCargo.Weight;
        }
    }
}