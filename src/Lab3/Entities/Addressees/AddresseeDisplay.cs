using Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayAdapters;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeDisplay : IAddressee
{
    private IDisplay _display;

    public AddresseeDisplay(IDisplay display, string title)
    {
        _display = display;
        Title = title;
    }

    public string Title { get; }
    public void GetMessage(Message message)
    {
        _display.PrintMessage(message);
    }
}