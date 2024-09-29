using System;
using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;

public class ShowConsoleCommand : Command
{
    private readonly Argument<string> _path = new("path");
    private readonly Option<string> _mode = new("-m", () => "console", "file output mode");

    public ShowConsoleCommand(FileSystemApp app)
        : base("show", "file output")
    {
        AddArgument(_path);
        AddOption(_mode);
        ArgumentNullException.ThrowIfNull(app);
        this.SetHandler(app.Execute, new FileShowCommandBinder(_path, _mode, app.OutputModeChain, app.Logger));
    }
}