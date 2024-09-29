using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(IAddressee addressee, Message message)
    {
        ArgumentNullException.ThrowIfNull(addressee);
        ArgumentNullException.ThrowIfNull(message);
        Console.Write($"A message was sent to the recipient {addressee.Title}" +
                           $"Message: {message.Header + message.Body}" +
                           $"Importance level is {message.ImportanceLevel}");
    }
}