using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

public class FileMoveCommandBinder : BinderBase<FileMoveCommand>
{
    private readonly Argument<string> _sourcePath;
    private readonly Argument<string> _destinationPath;
    private readonly ILogger _logger;

    public FileMoveCommandBinder(Argument<string> sourcePath, Argument<string> destinationPath, ILogger logger)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
        _logger = logger;
    }

    protected override FileMoveCommand GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new FileMoveCommand(
            bindingContext.ParseResult.GetValueForArgument(_sourcePath),
            bindingContext.ParseResult.GetValueForArgument(_destinationPath),
            _logger);
    }
}