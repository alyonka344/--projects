using Itmo.ObjectOrientedProgramming.Lab2.Models.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Corps;

public interface ICorpBuilder
{
    public ICorpBuilder WithName(string name);
    public ICorpBuilder WithMaxVideoCardDimension(VideoCardDimension maxVideoCardDimension);
    public ICorpBuilder AddMotherboardFormFactor(string motherboardFormFactor);
    public ICorpBuilder WithDimension(Dimension dimension);
    public Corp Build();
}