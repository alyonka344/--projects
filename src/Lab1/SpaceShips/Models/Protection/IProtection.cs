using Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection;

public interface IProtection
{
    public CollisionResult.CollisionResult AbsorbDamage(int damage);
    public CollisionResult.CollisionResult AbsorbFlare(IObstacle obstacle);
}