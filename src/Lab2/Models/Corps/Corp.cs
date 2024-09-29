using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Corps;

public class Corp : IBuildDirector<ICorpBuilder>, IComponent
{
    public Corp(
        string? name,
        VideoCardDimension? maxVideoCardDimension,
        IEnumerable<string> motherboardFormFactors,
        Dimension? dimensions)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        MaxVideoCardDimension = maxVideoCardDimension ?? throw new ArgumentNullException(nameof(maxVideoCardDimension));
        MotherboardFormFactors = motherboardFormFactors;
        Dimensions = dimensions ?? throw new ArgumentNullException(nameof(dimensions));
    }

    public string Name { get; }
    public VideoCardDimension MaxVideoCardDimension { get; }
    public IEnumerable<string> MotherboardFormFactors { get; }
    public Dimension Dimensions { get; }

    public ICorpBuilder Direct(ICorpBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithName(Name);
        builder.WithMaxVideoCardDimension(MaxVideoCardDimension);
        builder.WithDimension(Dimensions);

        foreach (string formFactor in MotherboardFormFactors)
        {
            builder.AddMotherboardFormFactor(formFactor);
        }

        return builder;
    }
}