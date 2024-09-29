using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;
    private readonly ILogger _logger;

    public FileRenameCommand(string path, string name, ILogger logger)
    {
        _path = path;
        _name = name;
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
            string newPath = new FileInfo(absolutPath).DirectoryName + '\\' + _name +
                             new FileInfo(absolutPath).Extension;
            if (File.Exists(newPath))
            {
                _logger.Log("file with name" + _name + "already exist");
                return;
            }

            File.Move(absolutPath, newPath);

            _logger.Log("file " + _path + " successfully renamed to: " + _name);
        }
        else
        {
            _logger.Log("file is not exist");
        }
    }
}