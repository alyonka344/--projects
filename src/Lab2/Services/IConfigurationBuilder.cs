namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IConfigurationBuilder
{
    public IConfigurationBuilder WithName(string name);
    public IConfigurationBuilder WithMotherboard(string motherboard);
    public IConfigurationBuilder WithCpu(string cpu);
    public IConfigurationBuilder WithCoolingSystem(string coolingSystem);
    public IConfigurationBuilder AddRam(string ram);
    public IConfigurationBuilder AddVideoCard(string videoCard);
    public IConfigurationBuilder AddSsd(string ssd);
    public IConfigurationBuilder AddHdd(string hdd);
    public IConfigurationBuilder WithCorp(string corp);
    public IConfigurationBuilder WithPowerUnit(string powerUnit);
    public IConfigurationBuilder WithWifiAdapter(string wifiAdapter);
    public Configuration Build();
}