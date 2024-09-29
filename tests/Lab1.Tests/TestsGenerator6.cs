using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services.FlightResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TestsGenerator6 : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[] { new PleasureShuttle(), typeof(ShipDestruction) },
        new object[] { new Vaklas(), typeof(ShipDestruction) },
        new object[] { new Meridian(), typeof(ShipLoss) },
        new object[] { new Stella(), typeof(ShipDestruction) },
        new object[] { new Vaklas(), typeof(ShipDestruction) },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}