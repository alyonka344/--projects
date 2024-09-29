using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

public class FileDeleteCommandBinder : BinderBase<FileDeleteCommand>
{
    private readonly Argument<string> _path;
    private readonly ILogger _logger;

    public FileDeleteCommandBinder(Argument<string> path, ILogger logger)
    {
        _path = path;
        _logger = logger;
    }

    protected override FileDeleteCommand GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new FileDeleteCommand(bindingContext.ParseResult.GetValueForArgument(_path), _logger);
    }
}