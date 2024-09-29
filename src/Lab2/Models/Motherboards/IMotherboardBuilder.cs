using Itmo.ObjectOrientedProgramming.Lab2.Models.BIOSs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Motherboards;

public interface IMotherboardBuilder
{
    public IMotherboardBuilder WithName(string name);
    public IMotherboardBuilder WithSocket(string socket);
    public IMotherboardBuilder WithPciLinesNumber(int pciLinesNumber);
    public IMotherboardBuilder WithSataPortsNumber(int sataPortsNumber);
    public IMotherboardBuilder AddChipSet(ChipSet chipSet);
    public IMotherboardBuilder WithSupportedDdrStandard(string supportedDdrStandard);
    public IMotherboardBuilder WithRamSlotsNumber(int ramSlotsNumber);
    public IMotherboardBuilder WithFormFactor(string formFactor);
    public IMotherboardBuilder WithBios(Bios bios);
    public Motherboard Build();
}