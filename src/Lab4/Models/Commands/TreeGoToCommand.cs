using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class TreeGoToCommand : ICommand
{
    private readonly string _path;
    private readonly ILogger _logger;

    public TreeGoToCommand(string path, ILogger logger)
    {
        _path = path;
        _logger = logger;
    }

    public void Execute(FileSystemWorkingDirectory fileSystemWorkingDirectory)
    {
        ArgumentNullException.ThrowIfNull(fileSystemWorkingDirectory);

        if (fileSystemWorkingDirectory.FileSystem is null)
        {
            _logger.Log("filesystem is not exist");
            return;
        }

        if (fileSystemWorkingDirectory.Directory is null)
        {
            _logger.Log("old directory is not exist");
            return;
        }

        string absolutPath = Path.GetFullPath(_path, fileSystemWorkingDirectory.Directory.AbsolutePath);

        fileSystemWorkingDirectory.Directory = fileSystemWorkingDirectory
            .FileSystem
            .DirectoryFactory
            .Create(absolutPath);

        if (!fileSystemWorkingDirectory.Directory.Exists())
        {
            _logger.Log("directory is not exist");
        }

        _logger.Log("directory successfully changed");
    }
}