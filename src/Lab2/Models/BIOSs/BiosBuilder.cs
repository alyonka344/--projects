using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BIOSs;

public class BiosBuilder : IBiosBuilder
{
    private string? _type;
    private string? _version;
    private List<string> _supportedProcessors = new();

    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder AddSupportedProcessors(string cpu)
    {
        _supportedProcessors.Add(cpu);
        return this;
    }

    public Bios Build()
    {
        return new Bios(
            _type,
            _version,
            _supportedProcessors);
    }
}