using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

public class ConsolePrinter : IPrinter
{
    public void Print<T>(T value)
    {
        if (value is null)
        {
            return;
        }

        Console.WriteLine(value.ToString());
    }
}