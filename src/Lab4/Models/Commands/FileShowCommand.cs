using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.FileShow;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileShowCommand : ICommand
{
    private readonly string _path;
    private readonly string _mode;
    private readonly ILogger _logger;
    private readonly IFileShowModeChain _modeChain;
    private IPrinter? _printer;

    public FileShowCommand(string path, string mode, IFileShowModeChain modeChain, ILogger logger)
    {
        _path = path;
        _mode = mode;
        _modeChain = modeChain;
        _logger = logger;
    }

    public void Execute(FileSystemWorkingDirectory fileSystemWorkingDirectory)
    {
        ArgumentNullException.ThrowIfNull(fileSystemWorkingDirectory);

        _printer = _modeChain.CheckMode(_mode);
        if (_printer is null)
        {
            _logger.Log("printing is not possible");
            return;
        }

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

        if (!File.Exists(absolutPath))
        {
            _logger.Log("file is not exist");
        }

        string text = File.ReadAllText(absolutPath);
        _printer.Print(absolutPath + ": ");
        _printer.Print(text);
        _logger.Log("success");
    }
}