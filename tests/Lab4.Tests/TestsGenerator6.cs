using System;
using System.Collections;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TestsGenerator6 : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[]
        {
            "../../../tests",
            "successful connection to directory: " + Environment.CurrentDirectory + "file with name 4.txt already exist in new directory",
            "../../../tests/test/4.txt",
        },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}