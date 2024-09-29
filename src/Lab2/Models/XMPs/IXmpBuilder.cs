namespace Itmo.ObjectOrientedProgramming.Lab2.Models.XMPs;

public interface IXmpBuilder
{
    public IXmpBuilder WithTimings(string timings);
    public IXmpBuilder WithVoltage(int voltage);
    public IXmpBuilder WithFrequency(int frequency);
    public Xmp Build();
}