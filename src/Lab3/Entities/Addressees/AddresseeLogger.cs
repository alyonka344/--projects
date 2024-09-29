using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeLogger : IAddressee
{
    private IAddressee _addressee;
    private ILogger _logger;

    public AddresseeLogger(IAddressee addressee, string title, ILogger logger)
    {
        _addressee = addressee;
        Title = title;
        _logger = logger;
    }

    public string Title { get; }
    public void GetMessage(Message message)
    {
        _addressee.GetMessage(message);
        _logger.Log(_addressee, message);
    }
}