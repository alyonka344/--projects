using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Printer;

public class FilePrinter : IPrinter
{
    private string _path;

    public FilePrinter(string path)
    {
        _path = path;
    }

    public void Print(string message)
    {
        File.WriteAllText(_path, message);
    }
}