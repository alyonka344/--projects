using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.FileShow;

public abstract class FileShowModeChainBase : IFileShowModeChain
{
    protected IFileShowModeChain? Next { get; private set; }

    public void AddNextMode(IFileShowModeChain nextMode)
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

    public abstract IPrinter? CheckMode(string mode);
}