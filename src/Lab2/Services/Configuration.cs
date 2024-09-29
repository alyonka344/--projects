using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Configuration
{
    public Configuration(
        string? name,
        string? motherboard,
        string? cpu,
        string? coolingSystem,
        IEnumerable<string> rams,
        IEnumerable<string> videoCards,
        IEnumerable<string> ssds,
        IEnumerable<string> hdds,
        string? corp,
        string? powerUnit,
        string? wifiAdapter)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Motherboard = motherboard ?? throw new ArgumentNullException(nameof(motherboard));
        Cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
        CoolingSystem = coolingSystem ?? throw new ArgumentNullException(nameof(coolingSystem));
        Rams = rams.ToList();
        VideoCards = videoCards.ToList();
        Ssds = ssds.ToList();
        Hdds = hdds.ToList();
        Corp = corp ?? throw new ArgumentNullException(nameof(corp));
        PowerUnit = powerUnit ?? throw new ArgumentNullException(nameof(powerUnit));
        WiFiAdapter = wifiAdapter;
    }

    public string Name { get; }
    public string Motherboard { get; }
    public string Cpu { get; }
    public string CoolingSystem { get; }
    public IEnumerable<string> Rams { get; }
    public IEnumerable<string> VideoCards { get; }
    public IEnumerable<string> Ssds { get; }
    public IEnumerable<string> Hdds { get; }
    public string Corp { get; }
    public string PowerUnit { get; }
    public string? WiFiAdapter { get; }
}