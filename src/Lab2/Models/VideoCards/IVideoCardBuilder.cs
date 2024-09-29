using Itmo.ObjectOrientedProgramming.Lab2.Models.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCards;

public interface IVideoCardBuilder
{
    public IVideoCardBuilder WithName(string name);
    public IVideoCardBuilder WithDimensions(VideoCardDimension dimensions);
    public IVideoCardBuilder WithMemoryAmount(int memoryAmount);
    public IVideoCardBuilder WithPsiVersion(string psiVersion);
    public IVideoCardBuilder WithChipFrequency(int chipFrequency);
    public IVideoCardBuilder WithPowerConsumption(int powerConsumption);
    public VideoCard Build();
}