using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}