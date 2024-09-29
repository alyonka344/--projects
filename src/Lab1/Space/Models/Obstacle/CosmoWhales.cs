namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;

public class CosmoWhales : INitrineParticlesObstacle
{
    private const int WhaleDamage = 150;

    public int Damage { get; } = WhaleDamage;
    public int Quantity { get; init; }
}