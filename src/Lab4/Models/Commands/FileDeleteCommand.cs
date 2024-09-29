using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;
    private readonly ILogger _logger;

    public FileDeleteCommand(string path, ILogger logger)
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

        if (File.Exists(absolutPath))
        {
            File.Delete(absolutPath);
            _logger.Log("file " + absolutPath + " successfully deleted");
        }
        else
        {
            _logger.Log("file is not exist");
        }
    }
}