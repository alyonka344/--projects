using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Strength;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;

public class Vaklas : SpaceShip
{
    public Vaklas()
        : base(
            new IProtection[] { new DeflectorC1(), new StrengthC2() },
            new Engine[] { new PulseEngineE(), new JumpEngineGamma() })
    {
    }
}