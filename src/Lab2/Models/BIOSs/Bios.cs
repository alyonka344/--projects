using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BIOSs;

public class Bios : IBuildDirector<IBiosBuilder>
{
    public Bios(
        string? type,
        string? version,
        IEnumerable<string> supportedProcessors)
    {
        Type = type ?? throw new ArgumentNullException(nameof(type));
        Version = version ?? throw new ArgumentNullException(nameof(version));
        SupportedProcessors = supportedProcessors;
    }

    public string Type { get; }
    public string Version { get; }
    public IEnumerable<string> SupportedProcessors { get; }

    public IBiosBuilder Direct(IBiosBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithType(Type);

        builder.WithVersion(Version);

        foreach (string supportedProcessor in SupportedProcessors)
        {
            builder.AddSupportedProcessors(supportedProcessor);
        }

        return builder;
    }
}