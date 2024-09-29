using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Corps;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CPUs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.HDDs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RAMs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.SSDs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapters;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

public class Computer : IBuildDirector<IComputerBuilder>
{
    public Computer(
        string? name,
        Motherboard? motherboard,
        Cpu? cpu,
        CoolingSystem? coolingSystem,
        ICollection<Ram> rams,
        ICollection<VideoCard> videoCards,
        ICollection<Ssd> ssds,
        ICollection<Hdd> hdds,
        Corp? corp,
        PowerUnit? powerUnit,
        WiFiAdapter? wiFiAdapter)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Motherboard = motherboard ?? throw new ArgumentNullException(nameof(motherboard));
        Cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
        CoolingSystem = coolingSystem ?? throw new ArgumentNullException(nameof(coolingSystem));
        Rams = rams;
        VideoCards = videoCards;
        Ssds = ssds;
        Hdds = hdds;
        Corp = corp ?? throw new ArgumentNullException(nameof(corp));
        PowerUnit = powerUnit ?? throw new ArgumentNullException(nameof(powerUnit));
        WiFiAdapter = wiFiAdapter;
        ValidationResults = new List<Result>();
    }

    public string Name { get; }
    public Motherboard Motherboard { get; }
    public Cpu Cpu { get; }
    public CoolingSystem CoolingSystem { get; }
    public ICollection<Ram> Rams { get; }
    public ICollection<VideoCard> VideoCards { get; }
    public ICollection<Ssd> Ssds { get; }
    public ICollection<Hdd> Hdds { get; }
    public Corp Corp { get; }
    public PowerUnit PowerUnit { get; }
    public WiFiAdapter? WiFiAdapter { get; }
    public ICollection<Result> ValidationResults { get; }

    public IComputerBuilder Direct(IComputerBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithName(Name);
        builder.WithMotherboard(Motherboard);
        builder.WithCpu(Cpu);
        builder.WithCoolingSystem(CoolingSystem);
        builder.WithCorp(Corp);
        builder.WithPowerUnit(PowerUnit);
        if (WiFiAdapter != null)
        {
            builder.WithWifiAdapter(WiFiAdapter);
        }

        foreach (VideoCard videoCard in VideoCards)
        {
            builder.AddVideoCard(videoCard);
        }

        foreach (Ram ram in Rams)
        {
            builder.AddRam(ram);
        }

        foreach (Ssd ssd in Ssds)
        {
            builder.AddSsd(ssd);
        }

        foreach (Hdd hdd in Hdds)
        {
            builder.AddHdd(hdd);
        }

        return builder;
    }

    public Result ValidationResult()
    {
        var validation = new Validation(this);
        ValidationResults.Add(validation.ValidVideoCardsNumber());
        ValidationResults.Add(validation.ValidCpuSocket());
        ValidationResults.Add(validation.ValidCpuBios());
        ValidationResults.Add(validation.ValidCoolingSystem());
        ValidationResults.Add(validation.ValidRamSlotsNumber());
        ValidationResults.Add(validation.ValidRamFrequency());
        ValidationResults.Add(validation.ValidNumberSsdHdd());
        ValidationResults.Add(validation.ValidVideoCardDimensions());
        ValidationResults.Add(validation.ValidMotherboardFormFactor());
        ValidationResults.Add(validation.ValidPowerUnit());

        ArgumentNullException.ThrowIfNull(ValidationResults);

        var res = new Result(string.Empty);

        if (ValidationResults.All(result => result is Success))
        {
            res = new Success();
        }

        if (ValidationResults.Any(result => result is BadPowerUnit))
        {
            res = new BadPowerUnit();
        }

        if (ValidationResults.Any(result => result is Fail))
        {
            res = new Fail("Invalid computer");
        }

        if (ValidationResults.Any(result => result is WarrantyDisclaimer))
        {
            res = new WarrantyDisclaimer("Warranty disclaimer");
        }

        return res;
    }
}