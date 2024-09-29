namespace Itmo.ObjectOrientedProgramming.Lab2.Models.SSDs;

public interface ISsdBuilder
{
    public ISsdBuilder WithName(string name);
    public ISsdBuilder WithConnectionOption(ConnectionOption connectionOption);
    public ISsdBuilder WithCapacity(int capacity);
    public ISsdBuilder WithMaxOperatingSpeed(int maxOperatingSpeed);
    public ISsdBuilder WithPowerConsumption(int powerConsumption);
    public Ssd Build();
}