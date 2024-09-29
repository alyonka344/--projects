using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Corps;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CPUs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.HDDs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RAMs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.SSDs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapters;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

public class ComputerBuilder : IComputerBuilder
{
    private string? _name;
    private Motherboard? _motherboard;
    private Cpu? _cpu;
    private CoolingSystem? _coolingSystem;
    private List<Ram> _rams = new();
    private List<VideoCard> _videoCards = new();
    private List<Ssd> _ssds = new();
    private List<Hdd> _hdds = new();
    private Corp? _corp;
    private PowerUnit? _powerUnit;
    private WiFiAdapter? _wifiAdapter;

    public IComputerBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IComputerBuilder WithMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IComputerBuilder WithCpu(Cpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IComputerBuilder WithCoolingSystem(CoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public IComputerBuilder AddRam(Ram ram)
    {
        _rams.Add(ram);
        return this;
    }

    public IComputerBuilder AddVideoCard(VideoCard videoCard)
    {
        _videoCards.Add(videoCard);
        return this;
    }

    public IComputerBuilder AddSsd(Ssd ssd)
    {
        _ssds.Add(ssd);
        return this;
    }

    public IComputerBuilder AddHdd(Hdd hdd)
    {
        _hdds.Add(hdd);
        return this;
    }

    public IComputerBuilder WithCorp(Corp corp)
    {
        _corp = corp;
        return this;
    }

    public IComputerBuilder WithPowerUnit(PowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IComputerBuilder WithWifiAdapter(WiFiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public Computer Build()
    {
        return new Computer(
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