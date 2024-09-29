using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.Connect;

public class LocalMode : ConnectModeChainBase
{
    private const string LocalModeName = "local";

    public override IFileSystem? CheckMode(string mode)
    {
        return mode == LocalModeName ? new LocalFileSystem() : Next?.CheckMode(mode);
    }
}