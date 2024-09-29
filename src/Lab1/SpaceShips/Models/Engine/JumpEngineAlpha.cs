using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;

public class JumpEngineAlpha : JumpEngine
{
    private const int JumpEngineAStartingSpeed = 50;
    public JumpEngineAlpha()
        : base(JumpEngineAStartingSpeed) { }

    public override Fuel.Fuel FuelCounting(int distance)
    {
        return new GravitonMatterFuel(FuelConsumptionJumpEngine * distance);
    }
}