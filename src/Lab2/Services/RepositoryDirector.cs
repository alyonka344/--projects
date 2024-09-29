using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Models.BIOSs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Corps;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CPUs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.HDDs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RAMs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.SSDs;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Models.XMPs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public static class RepositoryDirector
{
    public static Repository CreateDefaultRepository(Repository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);

        Bios bios = new BiosBuilder()
            .WithType("Bios")
            .WithVersion("3")
            .AddSupportedProcessors("AMD RYZEN 5 5600X")
            .AddSupportedProcessors("Intel Core i5-12400F")
            .Build();

        Motherboard motherBoard1 = new MotherboardBuilder()
            .WithName("GIGABYTE B550 AORUS ELITE V2")
            .WithSocket("AM4")
            .WithPciLinesNumber(4)
            .WithSataPortsNumber(4)
            .AddChipSet(new ChipSet(3000, new Xmp("18-18-18-15", 4, 3300)))
            .WithRamSlotsNumber(4)
            .WithSupportedDdrStandard("DDR4-DIMM")
            .WithBios(bios)
            .WithFormFactor("Standard-ATX")
            .Build();

        repository.Register(motherBoard1);

        Motherboard motherBoard2 = new MotherboardBuilder()
            .WithName("MSI MAG Z690 TOMAHAWK")
            .WithSocket("LGA 1700")
            .WithPciLinesNumber(4)
            .WithSataPortsNumber(6)
            .AddChipSet(new ChipSet(3000, new Xmp("18-18-18-15", 4, 3300)))
            .WithRamSlotsNumber(4)
            .WithSupportedDdrStandard("DDR4-DIMM")
            .WithBios(bios)
            .WithFormFactor("Standard-ATX")
            .Build();

        repository.Register(motherBoard2);

        Cpu cpu2 = new CpuBuilder()
            .WithName("AMD RYZEN 5 5600X")
            .WithCoreFrequency(3700)
            .WithCoreNumber(6)
            .WithSocket("AM4")
            .AddMemoryFrequency(3200)
            .WithHeatGeneration(65)
            .WithPowerConsumption(140)
            .Build();

        repository.Register(cpu2);

        Cpu cpu1 = new CpuBuilder()
            .WithName("Intel Core i5-12400F")
            .WithCoreFrequency(2500)
            .WithCoreNumber(6)
            .WithSocket("LGA 1700")
            .AddMemoryFrequency(4800)
            .WithHeatGeneration(65)
            .WithPowerConsumption(115)
            .Build();

        repository.Register(cpu1);

        Ram ram1 = new RamBuilder()
            .WithName("Kingston FURY Beast Black")
            .WithMemorySize(16)
            .AddJedec(new Jedec(3200, 10))
            .WithDdrVersion("DDR4-DIMM")
            .WithPowerConsumption(10)
            .WithFormFactor("ok")
            .Build();

        repository.Register(ram1);

        Ram ram2 = new RamBuilder()
            .WithName("Patriot Viper Venom")
            .WithMemorySize(16)
            .AddJedec(new Jedec(3200, 10))
            .WithDdrVersion("DDR5-DIMM")
            .WithPowerConsumption(10)
            .WithFormFactor("ok")
            .Build();

        repository.Register(ram2);

        CoolingSystem coolingSystem1 = new CoolingSystemBuilder()
            .WithName("DEEPCOOL AK620")
            .AddSupportedSocket("AM4")
            .AddSupportedSocket("LGA 1700")
            .WithTdp(200)
            .WithDimensions(new Dimension(10, 20, 50))
            .Build();

        repository.Register(coolingSystem1);

        CoolingSystem coolingSystem2 = new CoolingSystemBuilder()
            .WithName("coolling system")
            .AddSupportedSocket("AM4")
            .AddSupportedSocket("LGA 1700")
            .WithTdp(50)
            .WithDimensions(new Dimension(10, 20, 50))
            .Build();

        repository.Register(coolingSystem2);

        VideoCard videoCard1 = new VideoCardBuilder()
            .WithName("KFA2 GeForce RTX 3060 CORE")
            .WithDimensions(new VideoCardDimension(245, 112))
            .WithPowerConsumption(100)
            .WithChipFrequency(1320)
            .WithPsiVersion("PCI-E 4.0")
            .WithMemoryAmount(0)
            .Build();

        repository.Register(videoCard1);

        VideoCard videoCard2 = new VideoCardBuilder()
            .WithName("Nvidia GeForce RTX 3080 ti CORE")
            .WithDimensions(new VideoCardDimension(300, 120))
            .WithPowerConsumption(130)
            .WithChipFrequency(1720)
            .WithPsiVersion("PCI-E 4.0")
            .WithMemoryAmount(0)
            .Build();

        repository.Register(videoCard2);

        Ssd ssd = new SsdBuilder()
            .WithName("SSD")
            .WithCapacity(1024)
            .WithConnectionOption(ConnectionOption.Sata)
            .WithMaxOperatingSpeed(10000)
            .WithPowerConsumption(15)
            .Build();

        repository.Register(ssd);

        Hdd hdd = new HddBuilder()
            .WithName("HDD")
            .WithCapacity(1024)
            .WithPowerConsumption(15)
            .WithSpindleSpeed(7600)
            .Build();

        repository.Register(hdd);

        Corp corp = new CorpBuilder()
            .WithName("computer case")
            .WithDimension(new Dimension(100, 100, 100))
            .AddMotherboardFormFactor("Standard-ATX")
            .WithMaxVideoCardDimension(new VideoCardDimension(250, 120))
            .Build();

        repository.Register(corp);

        var powerUnit1 = new PowerUnit("Good power unit", 600);
        var powerUnit2 = new PowerUnit("Low power unit", 200);

        repository.Register(powerUnit1);
        repository.Register(powerUnit2);

        return repository;
    }
}