using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Printer;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayAdapters;

public class DisplayAdapter : IDisplay
{
    private Display _display;
    private IDisplayDriver _displayDriver;

    public DisplayAdapter(Display display, IDisplayDriver displayDriver)
    {
        _display = display;
        _displayDriver = displayDriver;
    }

    public void SetConsolePrinter()
    {
        _display.ChangePrinter(new ConsolePrinter());
    }

    public void SetFilePrinter(string path)
    {
        _display.ChangePrinter(new FilePrinter(path));
    }

    public void PrintMessage(Message message)
    {
        _displayDriver.ClearOutput();
        ArgumentNullException.ThrowIfNull(message);
        _displayDriver.Message = message.Header + message.Body;
        _display.Print(_displayDriver.Message);
    }

    public void SetColor(Color color)
    {
        _displayDriver.Color = color;
    }
}