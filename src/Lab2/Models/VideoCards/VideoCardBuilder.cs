using Itmo.ObjectOrientedProgramming.Lab2.Models.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCards;

public class VideoCardBuilder : IVideoCardBuilder
{
    private string? _name;
    private VideoCardDimension? _dimensions;
    private int? _memoryAmount;
    private string? _pciVersion;
    private int? _chipFrequency;
    private int? _powerConsumption;

    public IVideoCardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IVideoCardBuilder WithDimensions(VideoCardDimension dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public IVideoCardBuilder WithMemoryAmount(int memoryAmount)
    {
        _memoryAmount = memoryAmount;
        return this;
    }

    public IVideoCardBuilder WithPsiVersion(string psiVersion)
    {
        _pciVersion = psiVersion;
        return this;
    }

    public IVideoCardBuilder WithChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IVideoCardBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public VideoCard Build()
    {
        return new VideoCard(
            _name,
            _dimensions,
            _memoryAmount,
            _pciVersion,
            _chipFrequency,
            _powerConsumption);
    }
}