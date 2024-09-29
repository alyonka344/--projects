using System;
using System.CommandLine;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.FileShow;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var modeChain = new LocalMode();
        var outputModeChain = new ConsoleMode();
        var app = new FileSystemApp(modeChain, outputModeChain);

        var rootCommand = new RootCommand("lab4");
        rootCommand.AddCommand(new ConnectConsoleCommand(app));
        rootCommand.AddCommand(new DisconnectConsoleCommand(app));
        rootCommand.AddCommand(new TreeConsoleCommand(app));
        rootCommand.AddCommand(new FileConsoleCommand(app));

        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            string? command = Console.ReadLine();
            if (!string.IsNullOrEmpty(command))
            {
                rootCommand.Invoke(command.Split(' '));
            }
        }
    }
}