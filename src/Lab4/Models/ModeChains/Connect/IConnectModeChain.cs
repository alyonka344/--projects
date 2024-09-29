using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.Connect;

public interface IConnectModeChain
{
    public void AddNextMode(IConnectModeChain nextMode);
    public IFileSystem? CheckMode(string mode);
}