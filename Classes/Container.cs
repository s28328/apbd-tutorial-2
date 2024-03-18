namespace Cwiczenie2.Classes;

public abstract class Container
{
    private static Dictionary<string, List<int>> serialCodeDict = new Dictionary<string, List<int>>
    {
        {"L",new List<int>{1}},
        {"C",new List<int>{1}},
        {"G",new List<int>{1}}
    };
    private double _massOfCargoInKg;
    private double _heightInCm;
    private double _tareWeightInKg;
    private double _depthInCm;
    private double _maxPayloadInKg;

    protected Container(double massOfCargoInKg, double heightInCm, double tareWeightInKg, double depthInCm, double maxPayloadInKg)
    {
        _massOfCargoInKg = massOfCargoInKg;
        _heightInCm = heightInCm;
        _tareWeightInKg = tareWeightInKg;
        _depthInCm = depthInCm;
        _maxPayloadInKg = maxPayloadInKg;
        setSerialCode();
    }

    public double MassOfCargoInKg
    {
        get => _massOfCargoInKg;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Mass of cargo can`t be less or equals zero");
            _massOfCargoInKg = value;
        }
    }

    public double HeightInCm
    {
        get => _heightInCm;
        set
        {
            if (value < 0)
                throw new ArgumentException("Height can`t be less or equals zero");
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

    public string SerialCode { get; }

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


    private void setSerialCode()
    {
        var type = this.GetType();
        string strType = type.Name;
        string key = strType switch
        {
            "LiquidContainer" => key = "L",
            "GasContainer" => key = "G",
            "RefrigeratedContainer" => key = "C"
        };
        var keyList = serialCodeDict[key];
        int code = keyList[^1];
        keyList.Add(code+1);
        string serialCode = $"KON-{key}-{code}";
    }
    
    

}