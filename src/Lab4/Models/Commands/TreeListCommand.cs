using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.DirectoriesVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class TreeListCommand : ICommand
{
    private readonly Visitor _visitor;
    private readonly ILogger _logger;
    private readonly int _depth;

    public TreeListCommand(int depth, ILogger logger)
    {
        _depth = depth;
        _visitor = new Visitor(depth);
        _logger = logger;
    }

    public void Execute(FileSystemWorkingDirectory fileSystemWorkingDirectory)
    {
        ArgumentNullException.ThrowIfNull(fileSystemWorkingDirectory);
        if (fileSystemWorkingDirectory.Directory is null)
        {
            _logger.Log("directory is null");
            return;
        }

        _visitor.Visit(fileSystemWorkingDirectory.Directory);
        _logger.Log("success");
    }
}