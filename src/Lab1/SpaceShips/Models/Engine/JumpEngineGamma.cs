using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;

public class JumpEngineGamma : JumpEngine
{
    private const int JumpEngineGStartingSpeed = 70;
    public JumpEngineGamma()
        : base(JumpEngineGStartingSpeed) { }

    public override Fuel.Fuel FuelCounting(int distance)
    {
        return new GravitonMatterFuel(FuelConsumptionJumpEngine * FuelConsumptionJumpEngine);
    }
}