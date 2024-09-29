using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.AddresseeGroup;

public class AddresseeGroupBuilder : IAddresseeGroupBuilder
{
    private List<User> _users = new();
    private string? _title;

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void WithTitle(string title)
    {
        _title = title;
    }

    public AddresseeGroup Build()
    {
        return new AddresseeGroup(_users, _title);
    }
}