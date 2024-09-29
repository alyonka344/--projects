namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.EngineWorkingTime;

public record FailedFlight(int FlightTime) : EngineWorkingTime(FlightTime);