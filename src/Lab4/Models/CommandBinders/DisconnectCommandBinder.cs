using System;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

public class DisconnectCommandBinder : BinderBase<DisconnectCommand>
{
    private readonly ILogger _logger;

    public DisconnectCommandBinder(ILogger logger)
    {
        _logger = logger;
    }

    protected override DisconnectCommand GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new DisconnectCommand(_logger);
    }
}