using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;

public interface ILogger
{
    public void Log(IAddressee addressee, Message message);
}