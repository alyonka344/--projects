using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;

public class JumpEngineOmega : JumpEngine
{
    private const int JumpEngineOStartingSpeed = 100;
    public JumpEngineOmega()
        : base(JumpEngineOStartingSpeed) { }

    public override Fuel.Fuel FuelCounting(int distance)
    {
        return new ActivePlasmaFuel((int)(FuelConsumptionJumpEngine * Math.Log(FuelConsumptionJumpEngine)));
    }
}