using System;
using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;

public class DisconnectConsoleCommand : Command
{
    public DisconnectConsoleCommand(FileSystemApp app)
        : base("disconnect", "disconnecting from the file system")
    {
        ArgumentNullException.ThrowIfNull(app);
        this.SetHandler(app.Execute, new DisconnectCommandBinder(app.Logger));
    }
}