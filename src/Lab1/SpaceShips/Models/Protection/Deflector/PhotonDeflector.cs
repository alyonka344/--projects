using System;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.CollisionResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Deflector;

public class PhotonDeflector : DeflectorModification
{
    private const int PhotonDeflectorHitPoints = 600;

    public PhotonDeflector(Deflector deflector)
        : base(PhotonDeflectorHitPoints, deflector) { }

    public override CollisionResult.CollisionResult AbsorbFlare(IObstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);
        return Absorb(obstacle.Damage) >= 0 ? new CollisionSuccess() : new CrewDied();
    }

    public override CollisionResult.CollisionResult AbsorbDamage(int damage)
    {
        ArgumentNullException.ThrowIfNull(Deflector);
        return Deflector.AbsorbDamage(damage);
    }
}