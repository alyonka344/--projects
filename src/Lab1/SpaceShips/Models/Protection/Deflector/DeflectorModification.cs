using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Deflector;

public abstract class DeflectorModification : Deflector
{
    private int _modificationHitPoints;

    protected DeflectorModification(int modificationHitPoints, Deflector? deflector)
        : base(deflector ??
               throw new ArgumentNullException(nameof(deflector), $"{nameof(deflector)} cannot be null"))
    {
        _modificationHitPoints = modificationHitPoints;
        Deflector = deflector;
    }

    protected Deflector? Deflector { get; private set; }

    protected int Absorb(int damage)
    {
        _modificationHitPoints -= damage;

        return _modificationHitPoints;
    }
}