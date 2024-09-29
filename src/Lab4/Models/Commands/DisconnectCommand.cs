using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class DisconnectCommand : ICommand
{
    private readonly ILogger _logger;

    public DisconnectCommand(ILogger logger)
    {
        _logger = logger;
    }

    public void Execute(FileSystemWorkingDirectory fileSystemWorkingDirectory)
    {
        ArgumentNullException.ThrowIfNull(fileSystemWorkingDirectory);
        if (fileSystemWorkingDirectory.Directory is not null)
        {
            _logger.Log("successful disconnection to directory: " + fileSystemWorkingDirectory.Directory.AbsolutePath);
        }

        fileSystemWorkingDirectory.Directory = null;
    }
}