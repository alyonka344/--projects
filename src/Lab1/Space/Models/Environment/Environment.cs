using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services.FlightResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Environment;

public abstract class Environment
{
    public int RouteLength { get; init; }

    public abstract FlightResult PossibleToFly(SpaceShip spaceShip);
}