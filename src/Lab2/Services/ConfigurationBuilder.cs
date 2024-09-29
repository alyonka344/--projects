using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ConfigurationBuilder : IConfigurationBuilder
{
    private string? _name;
    private string? _motherboard;
    private string? _cpu;
    private string? _coolingSystem;
    private List<string> _rams = new();
    private List<string> _videoCards = new();
    private List<string> _ssds = new();
    private List<string> _hdds = new();
    private string? _corp;
    private string? _powerUnit;
    private string? _wifiAdapter;

    public IConfigurationBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IConfigurationBuilder WithMotherboard(string motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IConfigurationBuilder WithCpu(string cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IConfigurationBuilder WithCoolingSystem(string coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public IConfigurationBuilder AddRam(string ram)
    {
        _rams.Add(ram);
        return this;
    }

    public IConfigurationBuilder AddVideoCard(string videoCard)
    {
        _videoCards.Add(videoCard);
        return this;
    }

    public IConfigurationBuilder AddSsd(string ssd)
    {
        _ssds.Add(ssd);
        return this;
    }

    public IConfigurationBuilder AddHdd(string hdd)
    {
        _hdds.Add(hdd);
        return this;
    }

    public IConfigurationBuilder WithCorp(string corp)
    {
        _corp = corp;
        return this;
    }

    public IConfigurationBuilder WithPowerUnit(string powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IConfigurationBuilder WithWifiAdapter(string wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public Configuration Build()
    {
        return new Configuration(
            _name,
            _motherboard,
            _cpu,
            _coolingSystem,
            _rams,
            _videoCards,
            _ssds,
            _hdds,
            _corp,
            _powerUnit,
            _wifiAdapter);
    }
}