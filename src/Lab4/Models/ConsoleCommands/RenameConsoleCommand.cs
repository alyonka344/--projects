using System;
using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;

public class RenameConsoleCommand : Command
{
    private Argument<string> _path = new("path");
    private Argument<string> _name = new("name");

    public RenameConsoleCommand(FileSystemApp app)
        : base("rename", "renames the specified file")
    {
        AddArgument(_path);
        AddArgument(_name);
        ArgumentNullException.ThrowIfNull(app);
        this.SetHandler(app.Execute, new FileRenameCommandBinder(_path, _name, app.Logger));
    }
}