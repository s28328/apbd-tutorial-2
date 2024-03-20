using Cwiczenie2.Classes.Cargos;
using Cwiczenie2.Interfaces;

namespace Cwiczenie2.Classes;

public class GasContainer : Container, ILoadable,IHazardNotifier
{
    public Cargo? Unload()
    {
        if (Cargo == null)
        {
            Console.WriteLine("Container has no cargo to unload.");
            return null;
        }
        MassOfCargoInKg = MassOfCargoInKg * 0.05;
        this.Cargo.Weight *= 0.95;
        var unloadedCargo = new GasCargo((GasCargo)this.Cargo);
        this.Cargo = null;
        return unloadedCargo;
    }

    public void Load(Cargo cargo)
    {
        if (cargo.GetType().Name != "GasCargo")
            throw new ArgumentException("Not valid type of cargo to load.");
        MassOfCargoInKg += cargo.Weight;
        this.Cargo = cargo;
    }
    public GasContainer(
        double heightInCm,
        double tareWeightInKg,
        double depthInCm,
        double maxPayloadInKg) : base( heightInCm, tareWeightInKg, depthInCm, maxPayloadInKg)
    {
    }

    public void HazardNotify(string message)
    {
        Console.WriteLine("Occured hazardous event!!");
        Console.WriteLine("Serial Code of Container:"+this.SerialCode);
    }
}
