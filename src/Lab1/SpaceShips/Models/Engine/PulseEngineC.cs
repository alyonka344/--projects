using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.EngineWorkingTime;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;

public class PulseEngineC : PulseEngine
{
    private const int StartingSpeedEngineC = 50;
    private const int FuelConsumptionEngineC = 20;
    private const int StartingFuelEngineC = 40;

    public PulseEngineC()
        : base(StartingFuelEngineC, FuelConsumptionEngineC) { }

    public override EngineWorkingTime.EngineWorkingTime TimeCounting(int distance)
    {
        return new SuccessedFlight(distance / StartingSpeedEngineC);
    }
}