using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services.FlightResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services;

public class Flight
{
    private readonly Entities.SpaceShip _spaceShip;
    private readonly Route _route;

    public Flight(Entities.SpaceShip spaceShip, Route route)
    {
        _spaceShip = spaceShip;
        _route = route;
    }

    public FlightResult.FlightResult FlightAttempt()
    {
        foreach (Environment environment in _route.Environments)
        {
            switch (environment.PossibleToFly(_spaceShip))
            {
                case ShipDestruction:
                    return new ShipDestruction();
                case ShipLoss:
                    return new ShipLoss();
                case CrewDeath:
                    return new CrewDeath();
            }
        }

        int? workingTime = _route.Environments.Aggregate<Environment, int?>(
            0, (current, environment) => current + environment.PossibleToFly(_spaceShip).Time);
        int? fuelCost = _route.Environments.Aggregate<Environment, int?>(
            0, (current, environment) => current + environment.PossibleToFly(_spaceShip).Cost);

        return new Success(workingTime, fuelCost);
    }
}