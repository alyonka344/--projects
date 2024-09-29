using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Printer;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class Display
{
    private Color _color;
    private IPrinter _printer;

    public Display(Color color)
    {
        _color = color;
        _printer = new ConsolePrinter();
    }

    public void ChangePrinter(IPrinter printer)
    {
        _printer = printer;
    }

    public void Print(string message)
    {
        _printer.Print(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(message));
    }
}