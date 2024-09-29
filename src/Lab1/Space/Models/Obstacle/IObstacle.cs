namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;

public interface IObstacle
{
    public int Damage { get; }
    public int Quantity { get; init; }
}