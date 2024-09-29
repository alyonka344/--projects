namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Fuel;

public record ActivePlasmaFuel(int WastedFuel, int FuelCost = 20) : Fuel(FuelCost, WastedFuel);