using Cwiczenie2.Interfaces;

namespace Cwiczenie2.Classes;

public class GasContainer : Container, ILoadable
{
    public GasContainer(double massOfCargoInKg,
        double heightInCm,
        double tareWeightInKg,
        double depthInCm,
        double maxPayloadInKg) : base(massOfCargoInKg, heightInCm, tareWeightInKg, depthInCm, maxPayloadInKg)
    {
    }

    public double Unload()
    {
        throw new NotImplementedException();
    }

    public double Load(double massOfCargo)
    {
        throw new NotImplementedException();
    }
}