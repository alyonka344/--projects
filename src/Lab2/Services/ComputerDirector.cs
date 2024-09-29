using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;
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
using Microsoft.CSharp.RuntimeBinder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerDirector
{
    private readonly ComputerBuilder _computerBuilder;

    public ComputerDirector(ComputerBuilder computerBuilder)
    {
        _computerBuilder = computerBuilder;
    }

    public Computer CreateComputer(Configuration configuration, Repository repository)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(repository);

        _computerBuilder.WithName(configuration.Name);

        repository.TryGetElement(configuration.Motherboard, out Motherboard? motherboard);
        if (motherboard is null)
        {
            throw new RuntimeBinderException($"Motherboard \"{configuration.Motherboard}\" is not found");
        }

        _computerBuilder.WithMotherboard(motherboard);

        repository.TryGetElement(configuration.Cpu, out Cpu? cpu);
        if (cpu is null)
        {
            throw new RuntimeBinderException($"Cpu \"{configuration.Cpu}\" is not found");
        }

        _computerBuilder.WithCpu(cpu);

        repository.TryGetElement(configuration.CoolingSystem, out CoolingSystem? coolingSystem);
        if (coolingSystem is null)
        {
            throw new RuntimeBinderException($"Cooling system \"{configuration.CoolingSystem}\" is not found");
        }

        _computerBuilder.WithCoolingSystem(coolingSystem);

        foreach (string currentRam in configuration.Rams)
        {
            repository.TryGetElement(currentRam, out Ram? ram);
            if (ram is null)
            {
                throw new RuntimeBinderException($"Ram \"{currentRam}\" is not found");
            }

            _computerBuilder.AddRam(ram);
        }

        foreach (string currentVideoCard in configuration.VideoCards)
        {
            repository.TryGetElement(currentVideoCard, out VideoCard? videoCard);
            if (videoCard is null)
            {
                throw new RuntimeBinderException($"Video card \"{currentVideoCard}\" is not found");
            }

            _computerBuilder.AddVideoCard(videoCard);
        }

        foreach (string currentSsd in configuration.Ssds)
        {
            repository.TryGetElement(currentSsd, out Ssd? ssd);
            if (ssd is null)
            {
                throw new RuntimeBinderException($"SSD \"{currentSsd}\" is not found");
            }

            _computerBuilder.AddSsd(ssd);
        }

        foreach (string currentHdd in configuration.Hdds)
        {
            repository.TryGetElement(currentHdd, out Hdd? hdd);
            if (hdd is null)
            {
                throw new RuntimeBinderException($"Ram \"{currentHdd}\" is not found");
            }

            _computerBuilder.AddHdd(hdd);
        }

        repository.TryGetElement(configuration.Corp, out Corp? corp);
        if (corp is null)
        {
            throw new RuntimeBinderException($"Corp \"{configuration.Corp}\" is not found");
        }

        _computerBuilder.WithCorp(corp);

        repository.TryGetElement(configuration.PowerUnit, out PowerUnit? powerUnit);
        if (powerUnit is null)
        {
            throw new RuntimeBinderException($"Power unit \"{configuration.PowerUnit}\" is not found");
        }

        _computerBuilder.WithPowerUnit(powerUnit);

        if (configuration.WiFiAdapter is not null)
        {
            repository.TryGetElement(configuration.WiFiAdapter, out WiFiAdapter? wifiAdapter);
            if (wifiAdapter is null)
            {
                throw new RuntimeBinderException($"WiFi adapter \"{configuration.WiFiAdapter}\" is not found");
            }

            _computerBuilder.WithWifiAdapter(wifiAdapter);
        }

        return _computerBuilder.Build();
    }
}