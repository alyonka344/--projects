using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayAdapters;

public interface IDisplay
{
    public void SetConsolePrinter();
    public void SetFilePrinter(string path);
    public void PrintMessage(Message message);
    public void SetColor(Color color);
}