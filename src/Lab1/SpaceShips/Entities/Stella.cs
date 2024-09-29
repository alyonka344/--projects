using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Strength;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;

public class Stella : SpaceShip
{
    public Stella()
        : base(
            new IProtection[] { new DeflectorC1(), new StrengthC1() },
            new Engine[] { new PulseEngineC(), new JumpEngineOmega() })
    {
    }
}