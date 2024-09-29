using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Printer;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class Telegram
{
    private readonly List<string> _messages = new();
    private readonly ConsolePrinter _printer = new();

    public void GetMessage(string message)
    {
        _messages.Add(message);

        _printer.Print("Messenger:\n" + _messages.Last());
    }
}