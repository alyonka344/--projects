using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;

public abstract class PulseEngine : Engine
{
    private readonly int _startingFuel;
    private readonly int _fuelConsumption;

    protected PulseEngine(int startingFuel, int fuelConsumption)
    {
        _startingFuel = startingFuel;
        _fuelConsumption = fuelConsumption;
    }

    public override Fuel.Fuel FuelCounting(int distance)
    {
        return new ActivePlasmaFuel((distance * _fuelConsumption) + _startingFuel);
    }
}