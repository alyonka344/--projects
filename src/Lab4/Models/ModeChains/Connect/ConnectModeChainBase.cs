using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.Connect;

public abstract class ConnectModeChainBase : IConnectModeChain
{
    protected IConnectModeChain? Next { get; private set; }

    public void AddNextMode(IConnectModeChain nextMode)
    {
        if (Next is null)
        {
            Next = nextMode;
        }
        else
        {
            Next.AddNextMode(nextMode);
        }
    }

    public abstract IFileSystem? CheckMode(string mode);
}