using Cwiczenie2.Classes;
using Cwiczenie2.Classes.Cargos;

namespace Cwiczenie2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Test");
        var gasContainer = new GasContainer(230, 500, 230, 1000);
        var liquidContainer = new LiquidContainer(230, 500, 230, 1000);
        var refrigeratedContainer =  new RefrigeratedContainer(230, 500, 230, 1000);
        var ArefrigeratedContainer =  new RefrigeratedContainer(230, 500, 230, 1000);
    }
}