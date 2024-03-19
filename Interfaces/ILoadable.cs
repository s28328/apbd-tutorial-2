using Cwiczenie2.Classes.Cargos;

namespace Cwiczenie2.Interfaces;

public interface ILoadable
{
    public double Unload();
    public void Load(Cargo cargo);
}