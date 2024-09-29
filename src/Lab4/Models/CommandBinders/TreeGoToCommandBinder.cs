using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

public class TreeGoToCommandBinder : BinderBase<TreeGoToCommand>
{
    private readonly Argument<string> _path;
    private readonly ILogger _logger;

    public TreeGoToCommandBinder(Argument<string> path, ILogger logger)
    {
        _path = path;
        _logger = logger;
    }

    protected override TreeGoToCommand GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new TreeGoToCommand(bindingContext.ParseResult.GetValueForArgument(_path), _logger);
    }
}