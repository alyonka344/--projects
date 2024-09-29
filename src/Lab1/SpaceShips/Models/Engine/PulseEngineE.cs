using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.EngineWorkingTime;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;

public class PulseEngineE : PulseEngine
{
    private const int FuelConsumptionEngineE = 30;
    private const int StartingFuelEngineE = 60;

    public PulseEngineE()
        : base(StartingFuelEngineE, FuelConsumptionEngineE) { }

    public override EngineWorkingTime.EngineWorkingTime TimeCounting(int distance)
    {
        return new SuccessedFlight((int)Math.Log(distance));
    }
}