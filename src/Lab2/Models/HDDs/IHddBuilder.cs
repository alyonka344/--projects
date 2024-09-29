namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HDDs;

public interface IHddBuilder
{
    public IHddBuilder WithName(string name);
    public IHddBuilder WithCapacity(int capacity);
    public IHddBuilder WithSpindleSpeed(int spindleSpeed);
    public IHddBuilder WithPowerConsumption(int powerConsumption);
    public Hdd Build();
}