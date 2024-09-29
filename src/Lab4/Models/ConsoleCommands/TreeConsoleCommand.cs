using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;

public class TreeConsoleCommand : Command
{
    public TreeConsoleCommand(FileSystemApp app)
        : base("tree")
    {
        AddCommand(new GoToConsoleCommand(app));
        AddCommand(new ListConsoleCommand(app));
    }
}