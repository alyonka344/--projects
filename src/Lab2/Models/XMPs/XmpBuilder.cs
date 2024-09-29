namespace Itmo.ObjectOrientedProgramming.Lab2.Models.XMPs;

public class XmpBuilder : IXmpBuilder
{
    private string? _timings;
    private int? _voltage;
    private int? _frequency;

    public IXmpBuilder WithTimings(string timings)
    {
        _timings = timings;
        return this;
    }

    public IXmpBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IXmpBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public Xmp Build()
    {
        return new Xmp(
            _timings,
            _voltage,
            _frequency);
    }
}