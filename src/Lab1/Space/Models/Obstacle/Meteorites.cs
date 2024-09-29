namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;

public class Meteorites : INormalSpaceObstacle
{
    private const int MeteoriteDamage = 15;

    public int Damage { get; } = MeteoriteDamage;
    public int Quantity { get; init; }
}