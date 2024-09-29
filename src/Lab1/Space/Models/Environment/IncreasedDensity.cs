using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.CollisionResult;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.EngineWorkingTime;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services.FlightResult;
using CrewDeath = Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services.FlightResult.CrewDeath;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Environment;

public class IncreasedDensity : Environment
{
    public IncreasedDensity(IReadOnlyCollection<IIncreasedDensityObstacle> obstacles, int routeLength)
    {
        Obstacles = obstacles;
        RouteLength = routeLength;
    }

    public IReadOnlyCollection<IIncreasedDensityObstacle> Obstacles { get; }

    public override FlightResult PossibleToFly(SpaceShip spaceShip)
    {
        foreach (IIncreasedDensityObstacle obstacle in Obstacles)
        {
            ArgumentNullException.ThrowIfNull(spaceShip);
            CollisionResult result = spaceShip.TryCollide(obstacle);
            switch (result)
            {
                case CrewDied:
                    return new CrewDeath();
                case CollisionFail:
                    return new ShipDestruction();
            }
        }

        ArgumentNullException.ThrowIfNull(spaceShip);
        Engine? jumpEngine = spaceShip.GetJumpEngine();
        if (jumpEngine is not null)
        {
            EngineWorkingTime flightTime = jumpEngine.TimeCounting(RouteLength);
            Fuel flightFuel = jumpEngine.FuelCounting(RouteLength);
            return flightTime is FailedFlight
                ? new ShipLoss()
                : new Success(flightTime.FlightTime, flightFuel.WastedFuel * flightFuel.FuelCost);
        }

        return new ShipLoss();
    }
}