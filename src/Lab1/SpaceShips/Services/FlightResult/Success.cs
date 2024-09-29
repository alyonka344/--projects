namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services.FlightResult;

public record Success(int? Time, int? Cost) : FlightResult(Time, Cost);