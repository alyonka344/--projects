using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.CPUs;

public class Cpu : IBuildDirector<ICpuBuilder>, IComponent
{
    public Cpu(
        string? name,
        int? coreFrequency,
        int? coreNumber,
        string? socket,
        VideoCore? videoCore,
        IEnumerable<int> memoryFrequencies,
        int? heatGeneration,
        int? powerConsumption)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        CoreFrequency = coreFrequency ?? throw new ArgumentNullException(nameof(coreFrequency));
        CoreNumber = coreNumber ?? throw new ArgumentNullException(nameof(coreNumber));
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
        VideoCore = videoCore;
        MemoryFrequencies = memoryFrequencies.ToList();
        HeatGeneration = heatGeneration ?? throw new ArgumentNullException(nameof(heatGeneration));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
    }

    public string Name { get; }
    public int CoreFrequency { get; }
    public int CoreNumber { get; }
    public string Socket { get; }
    public VideoCore? VideoCore { get; }
    public IEnumerable<int> MemoryFrequencies { get; }
    public int HeatGeneration { get; }
    public int PowerConsumption { get; }

    public ICpuBuilder Direct(ICpuBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithName(Name);
        builder.WithCoreFrequency(CoreFrequency);
        builder.WithCoreNumber(CoreNumber);
        builder.WithSocket(Socket);
        if (VideoCore is not null)
        {
            builder.WithVideoCore(VideoCore);
        }

        builder.WithHeatGeneration(HeatGeneration);
        builder.WithPowerConsumption(PowerConsumption);

        foreach (int frequency in MemoryFrequencies)
        {
            builder.AddMemoryFrequency(frequency);
        }

        return builder;
    }
}