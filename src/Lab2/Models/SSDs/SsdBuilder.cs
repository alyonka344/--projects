namespace Itmo.ObjectOrientedProgramming.Lab2.Models.SSDs;

public class SsdBuilder : ISsdBuilder
{
    private string? _name;
    private ConnectionOption? _connectionOption;
    private int? _capacity;
    private int? _maxOperatingSpeed;
    private int? _powerConsumption;

    public ISsdBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ISsdBuilder WithConnectionOption(ConnectionOption connectionOption)
    {
        _connectionOption = connectionOption;
        return this;
    }

    public ISsdBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public ISsdBuilder WithMaxOperatingSpeed(int maxOperatingSpeed)
    {
        _maxOperatingSpeed = maxOperatingSpeed;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ssd Build()
    {
        return new Ssd(
            _name,
            _connectionOption,
            _capacity,
            _maxOperatingSpeed,
            _powerConsumption);
    }
}