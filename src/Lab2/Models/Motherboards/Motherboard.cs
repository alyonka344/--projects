using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.BIOSs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Motherboards;

public class Motherboard : IBuildDirector<IMotherboardBuilder>, IComponent
{
    public Motherboard(
        string? name,
        string? socket,
        int? pciLinesNumber,
        int? sataPortsNumber,
        IEnumerable<ChipSet> chipSets,
        string? supportedDdrStandard,
        int? ramSlotsNumber,
        string? formFactor,
        Bios? bios)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
        PciLinesNumber = pciLinesNumber ?? throw new ArgumentNullException(nameof(pciLinesNumber));
        SataPortsNumber = sataPortsNumber ?? throw new ArgumentNullException(nameof(sataPortsNumber));
        ChipSets = chipSets;
        SupportedDdrStandard = supportedDdrStandard ?? throw new ArgumentNullException(nameof(supportedDdrStandard));
        RamSlotsNumber = ramSlotsNumber ?? throw new ArgumentNullException(nameof(ramSlotsNumber));
        FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        Bios = bios ?? throw new ArgumentNullException(nameof(bios));
    }

    public string Name { get; }
    public string Socket { get; }
    public int PciLinesNumber { get; }
    public int SataPortsNumber { get; }
    public IEnumerable<ChipSet> ChipSets { get; }
    public string SupportedDdrStandard { get; }
    public int RamSlotsNumber { get; }
    public string FormFactor { get; }
    public Bios Bios { get; }

    public IMotherboardBuilder Direct(IMotherboardBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithName(Name);
        builder.WithSocket(Socket);
        builder.WithPciLinesNumber(PciLinesNumber);
        builder.WithSataPortsNumber(SataPortsNumber);
        builder.WithSupportedDdrStandard(SupportedDdrStandard);
        builder.WithRamSlotsNumber(RamSlotsNumber);
        builder.WithFormFactor(FormFactor);
        builder.WithBios(Bios);

        foreach (ChipSet chipSet in ChipSets)
        {
            builder.AddChipSet(chipSet);
        }

        return builder;
    }
}