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

public interface IComputerBuilder
{
    public IComputerBuilder WithName(string name);
    public IComputerBuilder WithMotherboard(Motherboard motherboard);
    public IComputerBuilder WithCpu(Cpu cpu);
    public IComputerBuilder WithCoolingSystem(CoolingSystem coolingSystem);
    public IComputerBuilder AddRam(Ram ram);
    public IComputerBuilder AddVideoCard(VideoCard videoCard);
    public IComputerBuilder AddSsd(Ssd ssd);
    public IComputerBuilder AddHdd(Hdd hdd);
    public IComputerBuilder WithCorp(Corp corp);
    public IComputerBuilder WithPowerUnit(PowerUnit powerUnit);
    public IComputerBuilder WithWifiAdapter(WiFiAdapter wifiAdapter);
    public Computer Build();
}