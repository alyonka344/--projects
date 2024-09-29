using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.FileShow;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;

public class FileSystemApp
{
    private readonly FileSystemWorkingDirectory _fileSystemWorkingDirectory = new();
    public FileSystemApp(IConnectModeChain modeChain, IFileShowModeChain outputModeChain)
    {
        ModeChain = modeChain;
        OutputModeChain = outputModeChain;
        Logger = new ConsoleLogger();
    }

    public FileSystemApp(IConnectModeChain modeChain, IFileShowModeChain outputModeChain, ILogger logger)
    {
        ModeChain = modeChain;
        OutputModeChain = outputModeChain;
        Logger = logger;
    }

    public IConnectModeChain ModeChain { get; }
    public IFileShowModeChain OutputModeChain { get; }
    public ILogger Logger { get; }

    public void Execute(ICommand command)
    {
        command?.Execute(_fileSystemWorkingDirectory);
    }
}