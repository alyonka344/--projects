using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Printer;

public class ConsolePrinter : IPrinter
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }
}