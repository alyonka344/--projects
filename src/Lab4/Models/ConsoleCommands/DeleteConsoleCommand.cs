using System;
using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;

public class DeleteConsoleCommand : Command
{
    private Argument<string> _path = new("path");
    public DeleteConsoleCommand(FileSystemApp app)
        : base("delete", "deletes the specified file")
    {
        AddArgument(_path);
        ArgumentNullException.ThrowIfNull(app);
        this.SetHandler(app.Execute, new FileDeleteCommandBinder(_path, app.Logger));
    }
}