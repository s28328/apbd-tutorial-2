namespace Cwiczenie2.Classes.ContainerShip;

public class ContainerShip
{
    public List<Container> Containers { get; set; }
    public double SpeedInKnot { get; }
    public int LimitOfContainers { get; }
    public double MaxPayloadInTon { get; set; }

    public ContainerShip(double speedInKnot, int limitOfContainers, double maxPayloadInTon)
    {
        SpeedInKnot = speedInKnot;
        LimitOfContainers = limitOfContainers;
        MaxPayloadInTon = maxPayloadInTon;
        Containers = new List<Container>();
    }

    public bool AddContainer(Container container)
    {
        double currPayloadInTon = MaxPayloadInTon + (container.MassOfCargoInKg + container.TareWeightInKg) / 1000;
        if (Containers.Count==LimitOfContainers)
        {
            Console.WriteLine("The ship is fully loaded with containers.");
            Console.WriteLine($"{container} is not loaded onto the ship.");
            return false;
        }
        else if(currPayloadInTon < this.MaxPayloadInTon)
        {
            Console.WriteLine("Payload of ship is overloaded.");
            Console.WriteLine($"{container} is not loaded onto the ship.");
            return false;
        }
        else
        {
            Containers.Add(container);
            this.MaxPayloadInTon = currPayloadInTon;
            Console.WriteLine($"{container} is loaded onto the ship");
            return true;
        }
    }
    public void AddContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            AddContainer(container);
        }
    }

    public Container ReplaceContainer(string shipContainerSerialCode, Container anotherContainer)
    {
        var shipContainer = Containers.Find(x => x.SerialCode == shipContainerSerialCode);
        if (shipContainer == null)
        {
            Console.WriteLine("No Container with this serial code on ship.");
            Console.WriteLine("Replacing denied.");
        }
        Containers.Remove(shipContainer);
        this.AddContainer(anotherContainer);
        return shipContainer;
    }

    public void TransferContainer(ContainerShip ship, Container container)
    {
        if (ship.AddContainer(container))
        {
            this.Containers.Remove(container);
        }
        else
        {
            Console.WriteLine($"Warning! {container} can`t be transferred!");
        }
    }

    public string Info()
    {
        string containersSerialCodes = "";
        foreach (var container in Containers)
        {
            containersSerialCodes += container + "\n";
        }

        return $"Ship:\n" +
               $"Container limit:{LimitOfContainers}\n" +
               $"Payload limit:{MaxPayloadInTon}(ton)\n" +
               $"Speed:{SpeedInKnot} (knot)\n" +
               $"List of containers:\n{containersSerialCodes}";
    }
}