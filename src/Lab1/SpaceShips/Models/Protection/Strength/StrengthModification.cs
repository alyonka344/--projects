namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Strength;

public abstract class StrengthModification : Protection.Strength.Strength
{
    protected StrengthModification(Strength strength)
        : base(strength)
    {
    }

    protected Strength? Strength { get; private set; }
}