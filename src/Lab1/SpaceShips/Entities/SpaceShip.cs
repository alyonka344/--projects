using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.CollisionResult;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Strength;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;

public abstract class SpaceShip
{
    private ICollection<IProtection> _shields;

    protected SpaceShip(ICollection<IProtection> shields, IReadOnlyCollection<Engine> engines)
    {
        _shields = shields;
        Engines = engines;
    }

    public IReadOnlyCollection<Engine> Engines { get; }

    public CollisionResult TryCollide(IObstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);
        if (obstacle is CosmoWhales)
        {
            if (_shields.Any(shield => shield is AntinitrineEmitter))
            {
                return new CollisionSuccess();
            }
        }

        if (obstacle is AntimatterFlares)
        {
            if (_shields.Any(shield => shield.AbsorbFlare(obstacle) is CollisionSuccess))
            {
                return new CollisionSuccess();
            }

            return new CrewDied();
        }

        int remainingDamage = _shields
            .Aggregate(obstacle.Damage, (damage, shield)
                => shield.AbsorbDamage(damage).RemainingDamage);
        if (remainingDamage is 0)
        {
            return new CollisionSuccess();
        }

        return new CollisionFail(remainingDamage);
    }

    public Engine? GetJumpEngine()
    {
        return Engines.FirstOrDefault(engine => engine is JumpEngine);
    }

    public Engine? GetPulseEngine()
    {
        return Engines.FirstOrDefault(engine => engine is PulseEngine);
    }

    public void SetPhotonDeflector()
    {
        var newShields = new List<IProtection>();
        foreach (IProtection shield in _shields)
        {
            if (shield is Deflector deflector)
            {
                IProtection newShield = new PhotonDeflector(deflector);
                newShields.Add(newShield);
            }
            else
            {
                newShields.Add(shield);
            }
        }

        _shields = newShields;
    }
}