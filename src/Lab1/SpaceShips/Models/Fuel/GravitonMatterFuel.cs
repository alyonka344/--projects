namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.Fuel;

public record GravitonMatterFuel(int WastedFuel, int FuelCost = 30) : Fuel(FuelCost, WastedFuel);