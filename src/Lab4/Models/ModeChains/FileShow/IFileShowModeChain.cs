using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.FileShow;

public interface IFileShowModeChain
{
    public void AddNextMode(IFileShowModeChain nextMode);
    public IPrinter? CheckMode(string mode);
}