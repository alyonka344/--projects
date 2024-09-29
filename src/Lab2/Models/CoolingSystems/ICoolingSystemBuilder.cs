using Itmo.ObjectOrientedProgramming.Lab2.Models.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.CoolingSystems;

public interface ICoolingSystemBuilder
{
    public ICoolingSystemBuilder WithName(string name);
    public ICoolingSystemBuilder WithDimensions(Dimension dimension);
    public ICoolingSystemBuilder AddSupportedSocket(string socket);
    public ICoolingSystemBuilder WithTdp(int tdp);
    public CoolingSystem Build();
}