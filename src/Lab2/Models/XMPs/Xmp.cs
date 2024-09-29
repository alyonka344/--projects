using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.XMPs;

public class Xmp : IBuildDirector<IXmpBuilder>
{
    public Xmp(
        string? timings,
        int? voltage,
        int? frequency)
    {
        Timings = timings ?? throw new ArgumentNullException(nameof(timings));
        Voltage = voltage ?? throw new ArgumentNullException(nameof(voltage));
        Frequency = frequency ?? throw new ArgumentNullException(nameof(frequency));
    }

    public string Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }
    public IXmpBuilder Direct(IXmpBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithTimings(Timings);
        builder.WithVoltage(Voltage);
        builder.WithFrequency(Frequency);

        return builder;
    }
}