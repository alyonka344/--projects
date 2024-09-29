using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Strength;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;

public class Meridian : SpaceShip
{
    public Meridian()
        : base(
            new IProtection[] { new DeflectorC2(), new AntinitrineEmitter(new StrengthC2()) },
            new Engine[] { new PulseEngineE() })
    {
    }
}