namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Users;

public abstract record LoginResult
{
    private LoginResult() { }

#pragma warning disable CA1034
    public sealed record Success : LoginResult;

    public sealed record NotFound : LoginResult;

    public sealed record WrongPassword : LoginResult;
#pragma warning restore CA1034
}