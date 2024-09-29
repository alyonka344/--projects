using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.EngineWorkingTime;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;

public abstract class JumpEngine : Engine
{
    private const int MaxJumpEngineWorkingTime = 300;
    private readonly int _startingSpeed;

    protected JumpEngine(int startingSpeed)
    {
        _startingSpeed = startingSpeed;
    }

    protected int FuelConsumptionJumpEngine { get; } = 25;
    public override EngineWorkingTime.EngineWorkingTime TimeCounting(int distance)
    {
        int flightTime = distance / _startingSpeed;

        return flightTime < MaxJumpEngineWorkingTime ? new SuccessedFlight(flightTime) :
            new FailedFlight(MaxJumpEngineWorkingTime);
    }
}