using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Corps;

public class CorpBuilder : ICorpBuilder
{
    private string? _name;
    private VideoCardDimension? _maxVideoCardDimension;
    private List<string> _motherboardFormFactors = new();
    private Dimension? _dimensions;

    public ICorpBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICorpBuilder WithMaxVideoCardDimension(VideoCardDimension maxVideoCardDimension)
    {
        _maxVideoCardDimension = maxVideoCardDimension;
        return this;
    }

    public ICorpBuilder AddMotherboardFormFactor(string motherboardFormFactor)
    {
        _motherboardFormFactors.Add(motherboardFormFactor);
        return this;
    }

    public ICorpBuilder WithDimension(Dimension dimension)
    {
        _dimensions = dimension;
        return this;
    }

    public Corp Build()
    {
        return new Corp(
            _name,
            _maxVideoCardDimension,
            _motherboardFormFactors,
            _dimensions);
    }
}