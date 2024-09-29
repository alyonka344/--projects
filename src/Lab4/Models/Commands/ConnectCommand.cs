using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.Connect;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _path;
    private readonly IConnectModeChain _modeChain;
    private readonly string _mode;
    private readonly ILogger _logger;

    public ConnectCommand(string path, IConnectModeChain modeChain, string mode, ILogger logger)
    {
        _path = path;
        _modeChain = modeChain;
        _mode = mode;
        _logger = logger;
    }

    public void Execute(FileSystemWorkingDirectory fileSystemWorkingDirectory)
    {
        ArgumentNullException.ThrowIfNull(fileSystemWorkingDirectory);

        fileSystemWorkingDirectory.FileSystem = _modeChain.CheckMode(_mode);
        if (fileSystemWorkingDirectory.FileSystem is null)
        {
            _logger.Log("mode is incorrect");
            return;
        }

        fileSystemWorkingDirectory.Directory = fileSystemWorkingDirectory.FileSystem.DirectoryFactory.Create(_path);
        if (!fileSystemWorkingDirectory.Directory.Exists())
        {
            _logger.Log("directory is not exist");
        }

        _logger.Log("successful connection to directory: " + _path);
    }
}