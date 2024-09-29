using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeFilter : IAddressee
{
    private IAddressee _addressee;
    private ImportanceLevel _importanceLevel;

    public AddresseeFilter(IAddressee addressee, ImportanceLevel importanceLevel, string title)
    {
        _addressee = addressee;
        _importanceLevel = importanceLevel;
        Title = title;
    }

    public string Title { get; }
    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if ((int)message.ImportanceLevel >= (int)_importanceLevel)
        {
            _addressee.GetMessage(message);
        }
    }
}