using System;
using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;

public class ConnectConsoleCommand : Command
{
    private readonly Option<string> _mode = new(
        "-m",
        "file system mode");

    private readonly Argument<string> _path = new("path");

    public ConnectConsoleCommand(FileSystemApp app)
        : base("connect", "connect to the file system")
    {
        AddArgument(_path);
        AddOption(_mode);
        ArgumentNullException.ThrowIfNull(app);
        this.SetHandler(app.Execute, new ConnectCommandBinder(_path, _mode, app.ModeChain, app.Logger));
    }
}