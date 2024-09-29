using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.CoolingSystems;

public class CoolingSystem : IBuildDirector<ICoolingSystemBuilder>, IComponent
{
    public CoolingSystem(
        string? name,
        Dimension? dimension,
        IEnumerable<string> supportedSockets,
        int? tdp)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Dimension = dimension ?? throw new ArgumentNullException(nameof(dimension));
        SupportedSockets = supportedSockets;
        Tdp = tdp ?? throw new ArgumentNullException(nameof(tdp));
    }

    public string Name { get; }
    public Dimension Dimension { get; }
    public IEnumerable<string> SupportedSockets { get; }
    public int Tdp { get; }
    public ICoolingSystemBuilder Direct(ICoolingSystemBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithName(Name);
        builder.WithDimensions(Dimension);
        builder.WithTdp(Tdp);

        foreach (string socket in SupportedSockets)
        {
            builder.AddSupportedSocket(socket);
        }

        return builder;
    }
}