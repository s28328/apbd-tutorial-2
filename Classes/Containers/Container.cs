using Cwiczenie2.Classes.Cargos;
using Cwiczenie2.Exceptions;

namespace Cwiczenie2.Classes;

public abstract class Container
{
    private static Dictionary<string, int> serialCodeDict = new Dictionary<string, int>
    {
        {"L", 1},
        {"C", 1},
        {"G", 1}
    };
    
    protected double _massOfCargoInKg;
    private double _heightInCm;
    private double _tareWeightInKg;
    private double _depthInCm;
    private double _maxPayloadInKg;

    protected Container( double heightInCm, double tareWeightInKg, double depthInCm, double maxPayloadInKg)
    {
        _massOfCargoInKg =0;
        _heightInCm = heightInCm;
        _tareWeightInKg = tareWeightInKg;
        _depthInCm = depthInCm;
        _maxPayloadInKg = maxPayloadInKg;
        SetSerialCode();
        Cargo = null;

    }
    
    
    public Cargo? Cargo { get; protected set; } 
    public virtual double MassOfCargoInKg
    {
        get => _massOfCargoInKg;
        set
        {
            if (value < 0)
                throw new ArgumentException("Mass of cargo can`t be less than zero.");
            else if (value > MaxPayloadInKg)
                throw new OverfillException("Overload of max payload.");
            _massOfCargoInKg = value;
        }
    }

    public double HeightInCm
    {
        get => _heightInCm;
        set
        {
            if (value < 0)
                throw new ArgumentException("Height can`t be less or equals zero.");
            _heightInCm = value;
        }
    }

    public double TareWeightInKg
    {
        get => _tareWeightInKg;
        set
        {
            if(value < 0)
                throw new ArgumentException("Tare weight can`t be less or equals zero");
            _tareWeightInKg = value;
        }
    }

    public double DepthInCm
    {
        get => _depthInCm;
        set
        {
            if(value<0)
                throw new ArgumentException("Depth can`t be less or equals zero");
            _depthInCm = value;
        }
    }

    public string SerialCode { get; private set; }

    public double MaxPayloadInKg
    {
        get => _maxPayloadInKg;
        set
        {
            if(value< 0)
                throw new ArgumentException("Max payload can`t be less or equals zero");
            _maxPayloadInKg = value;
        }
    }


    private void SetSerialCode()
    {
        var type = this.GetType();
        string strType = type.Name;
        string key = strType switch
        {
            "LiquidContainer" => key = "L",
            "GasContainer" => key = "G",
            "RefrigeratedContainer" => key = "C"
        };
        
        int code = serialCodeDict[key];
        serialCodeDict[key] = code + 1;
        this.SerialCode = $"KON-{key}-{code}";
    }
    
    

}