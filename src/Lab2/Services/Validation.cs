using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Validation
{
    private readonly Computer _computer;

    public Validation(Computer computer)
    {
        _computer = computer;
    }

    public Result ValidVideoCardsNumber()
    {
        return _computer.VideoCards.Count is not 0 || _computer.Cpu.VideoCore is not null ? new Success()
            : new Fail("Video card number invalid");
    }

    public Result ValidCpuSocket()
    {
        return _computer.Motherboard.Socket == _computer.Cpu.Socket ? new Success()
            : new Fail("Different sockets");
    }

    public Result ValidCpuBios()
    {
        return _computer.Motherboard.Bios.SupportedProcessors
            .Any(supportedProcessor => supportedProcessor == _computer.Cpu.Name)
            ? new Success()
            : new Fail("Cpu is not supported");
    }

    public Result ValidCoolingSystem()
    {
        return _computer.CoolingSystem.Tdp < _computer.Cpu.HeatGeneration
            ? new WarrantyDisclaimer("Tdp less cpu heat generation")
            : new Success();
    }

    public Result ValidRamSlotsNumber()
    {
        return _computer.Motherboard.RamSlotsNumber < _computer.Rams.Count
            ? new Fail("Few ram slots")
            : new Success();
    }

    public Result ValidRamFrequency()
    {
        return _computer.Rams
            .Any(ram => _computer.Motherboard.ChipSets
                .Any(chipSet => ram.Jedecs
                    .Any(jedec => chipSet.MemoryFrequency < jedec.Frequency)))
            ? new Success()
            : new Fail("Invalid ram frequency");
    }

    public Result ValidNumberSsdHdd()
    {
        return _computer.Hdds.Count is 0 && _computer.Ssds.Count is 0
            ? new Fail("Hdd or Ssd is not exist")
            : new Success();
    }

    public Result ValidVideoCardDimensions()
    {
        return _computer.VideoCards
            .All(card => card.Dimensions.Height < _computer.Corp.MaxVideoCardDimension.Height
                         && card.Dimensions.Length < _computer.Corp.MaxVideoCardDimension.Length)
            ? new Success()
            : new Fail("Video card dimension bigger case dimensions");
    }

    public Result ValidMotherboardFormFactor()
    {
        return _computer.Corp.MotherboardFormFactors
            .Any(formFactor => formFactor == _computer.Motherboard.FormFactor)
            ? new Success()
            : new Fail("Motherboard form factor invalid");
    }

    public Result ValidPowerUnit()
    {
        int resPowerConsumption = _computer.Hdds.Sum(hdd => hdd.PowerConsumption) +
                                  _computer.Ssds.Sum(ssd => ssd.PowerConsumption) +
                                  _computer.VideoCards.Sum(videoCard => videoCard.PowerConsumption) +
                                  _computer.Rams.Sum(ram => ram.PowerConsumption) +
                                  _computer.Cpu.PowerConsumption;
        if (resPowerConsumption > _computer.PowerUnit.PickLoad)
        {
            return new BadPowerUnit();
        }

        return new Success();
    }
}