using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.CollisionResult;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.EngineWorkingTime;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services.FlightResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Environment;

public class NormalSpace : Environment
{
    public NormalSpace(IReadOnlyCollection<INormalSpaceObstacle> obstacles, int routeLength)
    {
        Obstacles = obstacles;
        RouteLength = routeLength;
    }

    public IReadOnlyCollection<INormalSpaceObstacle> Obstacles { get; }

    public override FlightResult PossibleToFly(SpaceShip spaceShip)
    {
        foreach (INormalSpaceObstacle obstacle in Obstacles)
        {
            ArgumentNullException.ThrowIfNull(spaceShip);
            if (spaceShip.TryCollide(obstacle) is CollisionFail)
            {
                return new ShipDestruction();
            }
        }

        Engine? pulseEngine = spaceShip?.GetPulseEngine();
        if (pulseEngine is not PulseEngine)
        {
            return new ShipDestruction();
        }

        EngineWorkingTime flightTime = pulseEngine.TimeCounting(RouteLength);
        Fuel flightFuel = pulseEngine.FuelCounting(RouteLength);
        return new Success(flightTime.FlightTime, flightFuel.WastedFuel * flightFuel.FuelCost);
    }
}