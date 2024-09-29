namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HDDs;

public class HddBuilder : IHddBuilder
{
    private string? _name;
    private int? _capacity;
    private int? _spindleSpeed;
    private int? _powerConsumption;

    public IHddBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IHddBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHddBuilder WithSpindleSpeed(int spindleSpeed)
    {
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public IHddBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Hdd Build()
    {
        return new Hdd(
            _name,
            _capacity,
            _spindleSpeed,
            _powerConsumption);
    }
}