using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestsGenerator3 : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[]
        {
            typeof(WarrantyDisclaimer), new ConfigurationBuilder()
                .WithMotherboard("GIGABYTE B550 AORUS ELITE V2")
                .WithCorp("computer case")
                .WithCpu("AMD RYZEN 5 5600X")
                .WithCoolingSystem("coolling system")
                .WithName("comp")
                .WithPowerUnit("Good power unit")
                .AddHdd("HDD")
                .AddRam("Kingston FURY Beast Black")
                .AddVideoCard("KFA2 GeForce RTX 3060 CORE")
                .Build(),
        },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}