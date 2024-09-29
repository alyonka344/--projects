using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HDDs;

public class Hdd : IBuildDirector<IHddBuilder>, IComponent
{
    public Hdd(
        string? name,
        int? capacity,
        int? spindleSpeed,
        int? powerConsumption)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Capacity = capacity ?? throw new ArgumentNullException(nameof(capacity));
        SpindleSpeed = spindleSpeed ?? throw new ArgumentNullException(nameof(spindleSpeed));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
    }

    public string Name { get; }
    public int Capacity { get; }
    public int SpindleSpeed { get; }
    public int PowerConsumption { get; }

    public IHddBuilder Direct(IHddBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithName(Name);
        builder.WithCapacity(Capacity);
        builder.WithSpindleSpeed(SpindleSpeed);
        builder.WithPowerConsumption(PowerConsumption);

        return builder;
    }
}