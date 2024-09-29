using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.AddresseeGroup;

public class AddresseeGroup : IAddressee
{
    private readonly List<User> _users;

    public AddresseeGroup(IEnumerable<User> users, string? title)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        _users = users.ToList();
    }

    public string Title { get; }
    public void GetMessage(Message message)
    {
        foreach (User user in _users)
        {
            user.AcceptMessage(message);
        }
    }
}