using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

internal class TextLogger : ILogger
{
    public string Text { get; set; } = new(string.Empty);
    public void Log(string message)
    {
        Text += message;
    }
}