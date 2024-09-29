using System;
using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;

public class ListConsoleCommand : Command
{
    private readonly Option<int> _depth = new("-d", () => 1, "output depth");

    public ListConsoleCommand(FileSystemApp app)
        : base("list", "listing directories for a specific depth")
    {
        AddOption(_depth);
        ArgumentNullException.ThrowIfNull(app);
        this.SetHandler(app.Execute, new TreeListCommandBinder(_depth, app.Logger));
    }
}