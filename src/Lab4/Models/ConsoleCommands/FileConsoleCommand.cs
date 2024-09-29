using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;

public class FileConsoleCommand : Command
{
    public FileConsoleCommand(FileSystemApp app)
        : base("file")
    {
        AddCommand(new DeleteConsoleCommand(app));
        AddCommand(new RenameConsoleCommand(app));
        AddCommand(new CopyConsoleCommand(app));
        AddCommand(new MoveConsoleCommand(app));
        AddCommand(new ShowConsoleCommand(app));
    }
}