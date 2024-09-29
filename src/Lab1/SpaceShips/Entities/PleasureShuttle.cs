using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Strength;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;

public class PleasureShuttle : SpaceShip
{
    public PleasureShuttle()
        : base(
            new IProtection[] { new StrengthC1() },
            new Engine[] { new PulseEngineC() })
    {
    }
}