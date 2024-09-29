namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Users;

public abstract record SignUpResult
{
    private SignUpResult() { }

#pragma warning disable CA1034
    public sealed record Success : SignUpResult;

    public sealed record AlreadyRegistered : SignUpResult;
#pragma warning restore CA1034
}