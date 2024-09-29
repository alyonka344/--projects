namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Protection.Deflector;

public class DeflectorC1 : Protection.Deflector.Deflector
{
    private const int DeflectorC1HitPoints = 10;

    public DeflectorC1()
        : base(DeflectorC1HitPoints) { }
}