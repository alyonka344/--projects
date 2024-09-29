namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

public record User(long Id, string Username, long Password, UserRole UserRole);