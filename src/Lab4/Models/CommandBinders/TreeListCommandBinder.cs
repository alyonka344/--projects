using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

public class TreeListCommandBinder : BinderBase<TreeListCommand>
{
    private readonly Option<int> _depth;
    private readonly ILogger _logger;

    public TreeListCommandBinder(Option<int> depth, ILogger logger)
    {
        _depth = depth;
        _logger = logger;
    }

    protected override TreeListCommand GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new TreeListCommand(bindingContext.ParseResult.GetValueForOption(_depth), _logger);
    }
}