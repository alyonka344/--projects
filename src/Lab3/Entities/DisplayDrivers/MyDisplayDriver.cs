using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;

public class MyDisplayDriver : IDisplayDriver
{
    public MyDisplayDriver(string message)
    {
        Message = message;
    }

    public Color Color { get; set; } = Color.White;
    public string Message { get; set; }

    public void ClearOutput()
    {
        Console.Clear();
    }
}