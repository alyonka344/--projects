using System;
using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;

public class MoveConsoleCommand : Command
{
    private readonly Argument<string> _sourcePath = new("source path");
    private readonly Argument<string> _destinationPath = new("destination path");

    public MoveConsoleCommand(FileSystemApp app)
        : base("move", "moving the file to the specified directory")
    {
        AddArgument(_sourcePath);
        AddArgument(_destinationPath);

        ArgumentNullException.ThrowIfNull(app);
        this.SetHandler(app.Execute, new FileMoveCommandBinder(_sourcePath, _destinationPath, app.Logger));
    }
}