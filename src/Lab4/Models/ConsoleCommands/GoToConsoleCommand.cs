using System;
using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;

public class GoToConsoleCommand : Command
{
    private readonly Argument<string> _path = new("path");

    public GoToConsoleCommand(FileSystemApp app)
        : base("goto", "change working directory")
    {
        AddArgument(_path);
        ArgumentNullException.ThrowIfNull(app);
        this.SetHandler(app.Execute, new TreeGoToCommandBinder(_path, app.Logger));
    }
}