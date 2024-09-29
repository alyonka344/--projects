using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.Connect;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

public class ConnectCommandBinder : BinderBase<ConnectCommand>
{
    private readonly Argument<string> _path;
    private readonly Option<string> _mode;
    private readonly IConnectModeChain _modeChain;
    private readonly ILogger _logger;

    public ConnectCommandBinder(Argument<string> path, Option<string> mode, IConnectModeChain modeChain, ILogger logger)
    {
        _path = path;
        _mode = mode;
        _modeChain = modeChain;
        _logger = logger;
    }

    protected override ConnectCommand GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new ConnectCommand(
            bindingContext.ParseResult.GetValueForArgument(_path),
            _modeChain,
            bindingContext.ParseResult.GetValueForOption(_mode) ?? throw new InvalidOperationException(),
            _logger);
    }
}