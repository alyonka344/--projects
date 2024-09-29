using Itmo.ObjectOrientedProgramming.Lab3.Entities.MessengerAdapters;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeMessenger : IAddressee
{
    private IMessenger _messenger;

    public AddresseeMessenger(IMessenger messenger, string title)
    {
        _messenger = messenger;
        Title = title;
    }

    public string Title { get; }
    public void GetMessage(Message message)
    {
        _messenger.GetMessage(message);
    }
}