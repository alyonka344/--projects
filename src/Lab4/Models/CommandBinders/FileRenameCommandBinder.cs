using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandBinders;

public class FileRenameCommandBinder : BinderBase<FileRenameCommand>
{
    private readonly Argument<string> _path;
    private readonly Argument<string> _name;
    private readonly ILogger _logger;

    public FileRenameCommandBinder(Argument<string> path, Argument<string> name, ILogger logger)
    {
        _path = path;
        _name = name;
        _logger = logger;
    }

    protected override FileRenameCommand GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new FileRenameCommand(
            bindingContext.ParseResult.GetValueForArgument(_path),
            bindingContext.ParseResult.GetValueForArgument(_name),
            _logger);
    }
}