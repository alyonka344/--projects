using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Strength;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;

public class Augur : SpaceShip
{
    public Augur()
        : base(
            new IProtection[] { new DeflectorC3(), new StrengthC3() },
            new Engine[] { new PulseEngineE(), new JumpEngineAlpha() })
    {
    }
}