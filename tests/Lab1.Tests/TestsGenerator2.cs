using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services.FlightResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TestsGenerator2 : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[] { new Vaklas(), new Vaklas(), typeof(CrewDeath), typeof(Success) },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}