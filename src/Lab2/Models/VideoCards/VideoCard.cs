using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCards;

public class VideoCard : IBuildDirector<IVideoCardBuilder>, IComponent
{
    public VideoCard(
        string? name,
        VideoCardDimension? dimensions,
        int? memoryAmount,
        string? pciVersion,
        int? chipFrequency,
        int? powerConsumption)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Dimensions = dimensions ?? throw new ArgumentNullException(nameof(dimensions));
        MemoryAmount = memoryAmount ?? throw new ArgumentNullException(nameof(memoryAmount));
        PciVersion = pciVersion ?? throw new ArgumentNullException(nameof(pciVersion));
        ChipFrequency = chipFrequency ?? throw new ArgumentNullException(nameof(chipFrequency));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
    }

    public string Name { get; }
    public VideoCardDimension Dimensions { get; }
    public int MemoryAmount { get; }
    public string PciVersion { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }
    public IVideoCardBuilder Direct(IVideoCardBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithName(Name);
        builder.WithDimensions(Dimensions);
        builder.WithMemoryAmount(MemoryAmount);
        builder.WithPsiVersion(PciVersion);
        builder.WithChipFrequency(ChipFrequency);
        builder.WithPowerConsumption(PowerConsumption);

        return builder;
    }
}