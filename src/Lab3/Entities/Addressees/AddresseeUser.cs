using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeUser : IAddressee
{
    private readonly User _user;

    public AddresseeUser(User user, string title)
    {
        _user = user;
        Title = title;
    }

    public string Title { get; }
    public void GetMessage(Message message)
    {
        _user.AcceptMessage(message);
    }
}