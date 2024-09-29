using System;
using System.Collections;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TestsGenerator7 : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[]
        {
            "successful connection to directory: " + Environment.CurrentDirectory + "success",
        },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}