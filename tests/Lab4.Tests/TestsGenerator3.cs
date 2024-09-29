using System;
using System.Collections;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TestsGenerator3 : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[]
        {
            "../../../tests/test/3.txt",
            "successful connection to directory: " + Environment.CurrentDirectory + "file ../../../tests/test/3.txt successfully renamed to: xm.txt",
            "xm.txt",
        },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}