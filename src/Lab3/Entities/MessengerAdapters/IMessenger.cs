using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.MessengerAdapters;

public interface IMessenger
{
    public void GetMessage(Message message);
}