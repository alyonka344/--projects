using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.CoolingSystems;

public class CoolingSystemBuilder : ICoolingSystemBuilder
{
    private string? _name;
    private Dimension? _dimensions;
    private List<string> _supportedSockets = new();
    private int? _tdp;

    public ICoolingSystemBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICoolingSystemBuilder WithDimensions(Dimension dimension)
    {
        _dimensions = dimension;
        return this;
    }

    public ICoolingSystemBuilder AddSupportedSocket(string socket)
    {
        _supportedSockets.Add(socket);
        return this;
    }

    public ICoolingSystemBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CoolingSystem Build()
    {
        return new CoolingSystem(
            _name,
            _dimensions,
            _supportedSockets,
            _tdp);
    }
}