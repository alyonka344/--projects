using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ModeChains.FileShow;

public class ConsoleMode : FileShowModeChainBase
{
    private const string LocalModeName = "console";

    public override IPrinter? CheckMode(string mode)
    {
        return mode == LocalModeName ? new ConsolePrinter() : Next?.CheckMode(mode);
    }
}