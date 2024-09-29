using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.BIOSs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Motherboards;

public class MotherboardBuilder : IMotherboardBuilder
{
    private string? _name;
    private string? _socket;
    private int? _pciLinesNumber;
    private int? _sataPortsNumber;
    private List<ChipSet> _chipSet = new();
    private string? _supportedDdrStandard;
    private int? _ramSlotsNumber;
    private string? _formFactor;
    private Bios? _bios;

    public IMotherboardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMotherboardBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherboardBuilder WithPciLinesNumber(int pciLinesNumber)
    {
        _pciLinesNumber = pciLinesNumber;
        return this;
    }

    public IMotherboardBuilder WithSataPortsNumber(int sataPortsNumber)
    {
        _sataPortsNumber = sataPortsNumber;
        return this;
    }

    public IMotherboardBuilder AddChipSet(ChipSet chipSet)
    {
        _chipSet.Add(chipSet);
        return this;
    }

    public IMotherboardBuilder WithSupportedDdrStandard(string supportedDdrStandard)
    {
        _supportedDdrStandard = supportedDdrStandard;
        return this;
    }

    public IMotherboardBuilder WithRamSlotsNumber(int ramSlotsNumber)
    {
        _ramSlotsNumber = ramSlotsNumber;
        return this;
    }

    public IMotherboardBuilder WithFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _name,
            _socket,
            _pciLinesNumber,
            _sataPortsNumber,
            _chipSet,
            _supportedDdrStandard,
            _ramSlotsNumber,
            _formFactor,
            _bios);
    }
}