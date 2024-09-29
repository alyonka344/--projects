using System;
using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ConsoleCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.FileShow;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    [Theory]
    [ClassData(typeof(TestsGenerator1))]
    public void FileShowTest_InputFileInformation(string query, string result)
    {
        // arrange
        var textLogger = new TextLogger();
        var modeChain = new LocalMode();
        var outputModeChain = new ConsoleMode();
        var app = new FileSystemApp(modeChain, outputModeChain, textLogger);

        var rootCommand = new RootCommand("lab4");
        rootCommand.AddCommand(new ConnectConsoleCommand(app));
        rootCommand.AddCommand(new DisconnectConsoleCommand(app));
        rootCommand.AddCommand(new TreeConsoleCommand(app));
        rootCommand.AddCommand(new FileConsoleCommand(app));

        // act
        rootCommand.Invoke(new[] { "connect", Environment.CurrentDirectory, "-m", "local" });
        rootCommand.Invoke(new[] { "file", "show", query });

        // assert
        Assert.Equal(result, ((TextLogger)app.Logger).Text);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator2))]
    public void FileDeleteTest_FileIsNotExist(string query, string result)
    {
        // arrange
        var textLogger = new TextLogger();
        var modeChain = new LocalMode();
        var outputModeChain = new ConsoleMode();
        var app = new FileSystemApp(modeChain, outputModeChain, textLogger);

        var rootCommand = new RootCommand("lab4");
        rootCommand.AddCommand(new ConnectConsoleCommand(app));
        rootCommand.AddCommand(new DisconnectConsoleCommand(app));
        rootCommand.AddCommand(new TreeConsoleCommand(app));
        rootCommand.AddCommand(new FileConsoleCommand(app));

        // act
        rootCommand.Invoke(new[] { "connect", Environment.CurrentDirectory, "-m", "local" });
        rootCommand.Invoke(new[] { "file", "delete", query });

        // assert
        Assert.Equal(result, ((TextLogger)app.Logger).Text);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator3))]
    public void FileRenameTest_FileMoved(string query, string result, string name)
    {
        // arrange
        var textLogger = new TextLogger();
        var modeChain = new LocalMode();
        var outputModeChain = new ConsoleMode();
        var app = new FileSystemApp(modeChain, outputModeChain, textLogger);

        var rootCommand = new RootCommand("lab4");
        rootCommand.AddCommand(new ConnectConsoleCommand(app));
        rootCommand.AddCommand(new DisconnectConsoleCommand(app));
        rootCommand.AddCommand(new TreeConsoleCommand(app));
        rootCommand.AddCommand(new FileConsoleCommand(app));

        // act
        rootCommand.Invoke(new[] { "connect", Environment.CurrentDirectory, "-m", "local" });
        rootCommand.Invoke(new[] { "file", "rename", query, name });

        // assert
        Assert.Equal(result, ((TextLogger)app.Logger).Text);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator4))]
    public void TreeGoToTest_FileMoved(string query, string result)
    {
        // arrange
        var textLogger = new TextLogger();
        var modeChain = new LocalMode();
        var outputModeChain = new ConsoleMode();
        var app = new FileSystemApp(modeChain, outputModeChain, textLogger);

        var rootCommand = new RootCommand("lab4");
        rootCommand.AddCommand(new ConnectConsoleCommand(app));
        rootCommand.AddCommand(new DisconnectConsoleCommand(app));
        rootCommand.AddCommand(new TreeConsoleCommand(app));
        rootCommand.AddCommand(new FileConsoleCommand(app));

        // act
        rootCommand.Invoke(new[] { "connect", Environment.CurrentDirectory, "-m", "local" });
        rootCommand.Invoke(new[] { "tree", "goto", query });

        // assert
        Assert.Equal(result, ((TextLogger)app.Logger).Text);
    }

    [Theory(Skip = "ок")]
    [ClassData(typeof(TestsGenerator5))]
    public void FileMoveTest_FailFileAlreadyExist(string destinationPath, string result, string sourcePath)
    {
        // arrange
        var textLogger = new TextLogger();
        var modeChain = new LocalMode();
        var outputModeChain = new ConsoleMode();
        var app = new FileSystemApp(modeChain, outputModeChain, textLogger);

        var rootCommand = new RootCommand("lab4");
        rootCommand.AddCommand(new ConnectConsoleCommand(app));
        rootCommand.AddCommand(new DisconnectConsoleCommand(app));
        rootCommand.AddCommand(new TreeConsoleCommand(app));
        rootCommand.AddCommand(new FileConsoleCommand(app));

        // act
        rootCommand.Invoke(new[] { "connect", Environment.CurrentDirectory, "-m", "local" });
        rootCommand.Invoke(new[] { "file", "move", sourcePath,  destinationPath });

        // assert
        Assert.Equal(result, ((TextLogger)app.Logger).Text);
    }

    [Theory(Skip = "ок2")]
    [ClassData(typeof(TestsGenerator6))]
    public void FileCopyTest_FailFileAlreadyExist(string destinationPath, string result, string sourcePath)
    {
        // arrange
        var textLogger = new TextLogger();
        var modeChain = new LocalMode();
        var outputModeChain = new ConsoleMode();
        var app = new FileSystemApp(modeChain, outputModeChain, textLogger);

        var rootCommand = new RootCommand("lab4");
        rootCommand.AddCommand(new ConnectConsoleCommand(app));
        rootCommand.AddCommand(new DisconnectConsoleCommand(app));
        rootCommand.AddCommand(new TreeConsoleCommand(app));
        rootCommand.AddCommand(new FileConsoleCommand(app));

        // act
        rootCommand.Invoke(new[] { "connect", Environment.CurrentDirectory, "-m", "local" });
        rootCommand.Invoke(new[] { "file", "copy", sourcePath, destinationPath });

        // assert
        Assert.Equal(result, ((TextLogger)app.Logger).Text);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator7))]
    public void TreeListTest_SuccessInput(string result)
    {
        // arrange
        var textLogger = new TextLogger();
        var modeChain = new LocalMode();
        var outputModeChain = new ConsoleMode();
        var app = new FileSystemApp(modeChain, outputModeChain, textLogger);
        string[] treeList = { "tree", "list" };

        var rootCommand = new RootCommand("lab4");
        rootCommand.AddCommand(new ConnectConsoleCommand(app));
        rootCommand.AddCommand(new DisconnectConsoleCommand(app));
        rootCommand.AddCommand(new TreeConsoleCommand(app));
        rootCommand.AddCommand(new FileConsoleCommand(app));

        // act
        rootCommand.Invoke(new[] { "connect", Environment.CurrentDirectory, "-m", "local" });
        rootCommand.Invoke(treeList);

        // assert
        Assert.Equal(result, ((TextLogger)app.Logger).Text);
    }
}