using Cwiczenie2.Classes.Cargos;
using Cwiczenie2.Interfaces;

namespace Cwiczenie2.Classes;

public class GasContainer : Container, ILoadable,IHazardNotifier
{
    public double Unload()
    {
        double unloadedCargo = MassOfCargoInKg;
        MassOfCargoInKg = MassOfCargoInKg * 0.05;
        return unloadedCargo;
    }

    public void Load(Cargo cargo)
    {
        if (cargo.GetType().Name != "GasCargo")
            throw new ArgumentException("Not valid type of cargo to load.");
        GasCargo gasCargo = (GasCargo)cargo;
        MassOfCargoInKg += gasCargo.Weight;
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
