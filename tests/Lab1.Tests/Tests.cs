using System;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services.FlightResult;
using Xunit;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Environment.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Tests
{
    [Theory]
    [ClassData(typeof(TestsGenerator1))]
    public void FlightAttempt_BothShouldReturnShipLoss_WhereSpaceIsIncreasedDensity(SpaceShip ship, Type expectedResult)
    {
        // arrange
        var environment = new IncreasedDensity(Array.Empty<IIncreasedDensityObstacle>(), 20000);
        var route = new Route(new[] { environment });
        var flight = new Flight(ship, route);

        // act
        FlightResult result = flight.FlightAttempt();

        // assert
        Assert.IsType(expectedResult, result);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator2))]
    public void FlightAttempt_FirstIsFailureSecondIsSuccess_WhereSpaceIsIncreasedDensityWithPhotonFlare(SpaceShip ship1, SpaceShip ship2, Type expectedResult1, Type expectedResult2)
    {
        // arrange
        var environment = new IncreasedDensity(new IIncreasedDensityObstacle[] { new AntimatterFlares() }, 20000);
        var route = new Route(new[] { environment });
        var flight1 = new Flight(ship1, route);

        ArgumentNullException.ThrowIfNull(ship2);
        ship2.SetPhotonDeflector();
        var flight2 = new Flight(ship2, route);

        // act
        FlightResult result1 = flight1.FlightAttempt();
        FlightResult result2 = flight2.FlightAttempt();

        // assert
        Assert.IsType(expectedResult1, result1);
        Assert.IsType(expectedResult2, result2);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator3))]
    public void FlightAttempt_FirstFailureSecondSuccessThirdSuccess_NitrineParticlesWithWhale(SpaceShip ship, Type expectedResult)
    {
        // arrange
        var environment = new NitrineParticles(new[] { new CosmoWhales() }, 1000);
        var route = new Route(new[] { environment });
        var flight = new Flight(ship, route);

        // act
        FlightResult result = flight.FlightAttempt();

        // assert
        Assert.IsType(expectedResult, result);
    }

    [Fact]
    public void FlightAttempt_PleasureShuttleShouldCostLessThanVaklas_NormalSpaceShortRoute()
    {
        // arrange
        var environment = new NormalSpace(Array.Empty<INormalSpaceObstacle>(), 1000);
        var route = new Route(new[] { environment });
        var flight1 = new Flight(new PleasureShuttle(), route);
        var flight2 = new Flight(new Vaklas(), route);

        // act
        FlightResult result1 = flight1.FlightAttempt();
        FlightResult result2 = flight2.FlightAttempt();

        // assert
        Assert.True(result1.Cost < result2.Cost);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator4))]
    public void FlightAttempt_StellaIsSuccessAugurIsFailure_IncreasedDensityMiddleRouteLength(SpaceShip ship, Type expectedResult)
    {
        // arrange
        var environment = new IncreasedDensity(Array.Empty<IIncreasedDensityObstacle>(), 20000);
        var route = new Route(new[] { environment });
        var flight = new Flight(ship, route);

        // act
        FlightResult result = flight.FlightAttempt();

        // assert
        Assert.IsType(expectedResult, result);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator5))]
    public void FlightAttempt_VaklasIsSuccessPleasureShuttleIsFailure_NitrineParticles(SpaceShip ship, Type expectedResult)
    {
        // arrange
        var environment = new NitrineParticles(Array.Empty<INitrineParticlesObstacle>(), 1500);
        var route = new Route(new[] { environment });
        var flight = new Flight(ship, route);

        // act
        FlightResult result = flight.FlightAttempt();

        // assert
        Assert.IsType(expectedResult, result);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator6))]
    public void FlightAttempt_AllWithoutMeridianDestructionMeridianLoss_NitrineParticles(SpaceShip ship, Type expectedResult)
    {
        // arrange
        var environment1 = new NitrineParticles(new[] { new CosmoWhales() }, 1500);
        var environment2 = new NormalSpace(new INormalSpaceObstacle[] { new Asteroids(), new Meteorites() }, 2000);
        var environment3 = new IncreasedDensity(Array.Empty<IIncreasedDensityObstacle>(), 20000);
        var route = new Route(new Environment[] { environment1, environment2, environment3 });
        var flight = new Flight(ship, route);

        // act
        FlightResult result = flight.FlightAttempt();

        // assert
        Assert.IsType(expectedResult, result);
    }
}