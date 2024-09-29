using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.FileShow;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

public class FileShowCommandBinder : BinderBase<FileShowCommand>
{
    private readonly Argument<string> _path;
    private readonly Option<string> _mode;
    private readonly IFileShowModeChain _modeChain;
    private readonly ILogger _logger;

    public FileShowCommandBinder(Argument<string> path, Option<string> mode, IFileShowModeChain modeChain, ILogger logger)
    {
        _path = path;
        _mode = mode;
        _modeChain = modeChain;
        _logger = logger;
    }

    protected override FileShowCommand GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new FileShowCommand(
            bindingContext.ParseResult.GetValueForArgument(_path),
            bindingContext.ParseResult.GetValueForOption(_mode) ?? throw new InvalidOperationException(),
            _modeChain,
            _logger);
    }
}