namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;

public class Asteroids : INormalSpaceObstacle
{
    private const int AsteroidDamage = 5;

    public int Damage { get; } = AsteroidDamage;
    public int Quantity { get; init; }
}