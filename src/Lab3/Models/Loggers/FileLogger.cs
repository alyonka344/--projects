using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

public class FileLogger : ILogger
{
    private string _path;

    public FileLogger(string path)
    {
        _path = path;
    }

    public void Log(IAddressee addressee, Message message)
    {
        ArgumentNullException.ThrowIfNull(addressee);
        ArgumentNullException.ThrowIfNull(message);
        File.AppendAllText(
            _path,
            $"A message was sent to the recipient {addressee.Title}\nMessage: {message.Header + message.Body}\nImportance level is {message.ImportanceLevel}");
    }
}