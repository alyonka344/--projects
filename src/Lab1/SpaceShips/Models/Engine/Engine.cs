namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;

public abstract class Engine
{
    public abstract EngineWorkingTime.EngineWorkingTime TimeCounting(int distance);
    public abstract Fuel.Fuel FuelCounting(int distance);
}