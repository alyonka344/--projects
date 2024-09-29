namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models.CollisionResult;

public sealed record CollisionFail(int RemainingDamage) : CollisionResult(RemainingDamage);