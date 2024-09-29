namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;

public class AntimatterFlares : IIncreasedDensityObstacle
{
    private const int FlareDamage = 200;

    public int Damage { get; } = FlareDamage;
    public int Quantity { get; init; }
}