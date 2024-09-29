namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

public interface IPrinter
{
    public void Print<T>(T value);
}