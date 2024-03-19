using Cwiczenie2.Classes.Cargos;
using Cwiczenie2.Interfaces;

namespace Cwiczenie2.Classes;

class LiquidContainer : Container, ILoadable, IHazardNotifier
{
 
    public double Unload()
    {
        throw new NotImplementedException();
    }

    public void Load(Cargo cargo)
    {
        if (cargo.GetType().Name != "LiquidCargo")
            throw new ArgumentException("Not valid type of cargo to load.");
        LiquidCargo liquidCargo = (LiquidCargo)cargo;
        if (liquidCargo.IsHazard)
        {
            if(liquidCargo.Weight <= 0.5*this.MaxPayloadInKg)
                this.MassOfCargoInKg = liquidCargo.Weight;
            else
                HazardNotify("Overload attempt of hazard cargo.");
        }
        else
        {
            if(liquidCargo.Weight <= 0.9*this.MaxPayloadInKg)
                this.MassOfCargoInKg = liquidCargo.Weight;
            else
                HazardNotify("Overload attempt of cargo.");
        }
    }

    public LiquidContainer(
        double heightInCm,
        double tareWeightInKg,
        double depthInCm,
        double maxPayloadInKg) : base( heightInCm, tareWeightInKg, depthInCm, maxPayloadInKg)
    {
    }

    public void HazardNotify(string message)
    {
        Console.WriteLine("Occured hazardous event!!");
        Console.WriteLine(message);
        Console.WriteLine("Serial Code of Container:"+this.SerialCode);
    }
}