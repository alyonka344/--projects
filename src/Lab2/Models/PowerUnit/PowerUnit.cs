namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PowerUnit;

public class PowerUnit : IComponent
{
    public PowerUnit(string name, int pickLoad)
    {
        Name = name;
        PickLoad = pickLoad;
    }

    public string Name { get; }
    public int PickLoad { get; }
}