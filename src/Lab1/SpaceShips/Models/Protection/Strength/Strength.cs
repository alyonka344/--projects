using System;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.CollisionResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Strength;

public abstract class Strength : IProtection
{
    private int _hitPoints;

    protected Strength(int hitPoints)
    {
        _hitPoints = hitPoints;
    }

    protected Strength(Strength strength)
    {
        ArgumentNullException.ThrowIfNull(strength);
        _hitPoints = strength._hitPoints;
    }

    public virtual CollisionResult.CollisionResult AbsorbDamage(int damage)
    {
        _hitPoints = _hitPoints <= 0 ? -damage : _hitPoints - damage;

        return _hitPoints < 0 ? new CollisionFail(-_hitPoints) : new CollisionSuccess();
    }

    public virtual CollisionResult.CollisionResult AbsorbFlare(IObstacle obstacle)
    {
        return obstacle is AntimatterFlares ? new CrewDied() : new CollisionSuccess();
    }
}