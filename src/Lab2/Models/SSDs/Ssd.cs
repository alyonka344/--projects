using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.SSDs;

public class Ssd : IBuildDirector<ISsdBuilder>, IComponent
{
    public Ssd(
        string? name,
        ConnectionOption? connectionOption,
        int? capacity,
        int? maxOperatingSpeed,
        int? powerConsumption)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        ConnectionOption = connectionOption ?? throw new ArgumentNullException(nameof(connectionOption));
        Capacity = capacity ?? throw new ArgumentNullException(nameof(capacity));
        MaxOperatingSpeed = maxOperatingSpeed ?? throw new ArgumentNullException(nameof(maxOperatingSpeed));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
    }

    public string Name { get; }
    public ConnectionOption ConnectionOption { get; }
    public int Capacity { get; }
    public int MaxOperatingSpeed { get; }
    public int PowerConsumption { get; }
    public ISsdBuilder Direct(ISsdBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithName(Name);
        builder.WithConnectionOption(ConnectionOption);
        builder.WithCapacity(Capacity);
        builder.WithMaxOperatingSpeed(MaxOperatingSpeed);
        builder.WithPowerConsumption(PowerConsumption);

        return builder;
    }
}