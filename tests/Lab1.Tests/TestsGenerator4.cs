using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services.FlightResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TestsGenerator4 : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[] { new Stella(), typeof(Success) },
        new object[] { new Augur(), typeof(ShipLoss) },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}