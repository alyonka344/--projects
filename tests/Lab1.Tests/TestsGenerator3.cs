using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services.FlightResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TestsGenerator3 : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[] { new Vaklas(), typeof(ShipDestruction) },
        new object[] { new Augur(), typeof(Success) },
        new object[] { new Meridian(), typeof(Success) },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}