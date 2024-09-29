using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.XMPs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.RAMs;

public class RamBuilder : IRamBuilder
{
    private string? _name;
    private int? _memorySize;
    private List<Jedec> _jedecs = new();
    private List<Xmp> _xmpProfiles = new();
    private string? _formFactor;
    private string? _ddrVersion;
    private int? _powerConsumption;

    public IRamBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IRamBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public IRamBuilder AddJedec(Jedec jedec)
    {
        _jedecs.Add(jedec);
        return this;
    }

    public IRamBuilder AddXmp(Xmp xmpProfile)
    {
        _xmpProfiles.Add(xmpProfile);
        return this;
    }

    public IRamBuilder WithFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRamBuilder WithDdrVersion(string ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public IRamBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ram Build()
    {
        return new Ram(
            _name,
            _memorySize,
            _jedecs,
            _xmpProfiles,
            _formFactor,
            _ddrVersion,
            _powerConsumption);
    }
}