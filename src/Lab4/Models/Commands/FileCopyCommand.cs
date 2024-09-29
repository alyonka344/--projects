using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileCopyCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;
    private readonly ILogger _logger;

    public FileCopyCommand(string sourcePath, string destinationPath, ILogger logger)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
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

        string absolutSourcePath = Path.GetFullPath(
            _sourcePath,
            fileSystemWorkingDirectory.Directory.AbsolutePath);

        string name = new FileInfo(absolutSourcePath).Name;

        string absolutDestinationPath = Path.GetFullPath(
            _destinationPath,
            fileSystemWorkingDirectory.Directory.AbsolutePath) + '\\' + name;

        if (File.Exists(absolutDestinationPath))
        {
            _logger.Log("file with name " + name + " already exist in new directory");
            return;
        }

        if (File.Exists(absolutSourcePath))
        {
            File.Copy(absolutSourcePath, absolutDestinationPath);

            _logger.Log("file " + name + " successfully copied from: " + absolutSourcePath +
                        " to: " + absolutDestinationPath);
        }
        else
        {
            _logger.Log("file is not exist");
        }
    }
}