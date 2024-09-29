using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.XMPs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.RAMs;

public class Ram : IBuildDirector<IRamBuilder>, IComponent
{
    public Ram(
        string? name,
        int? memorySize,
        IEnumerable<Jedec> jedecs,
        IEnumerable<Xmp> xmpProfiles,
        string? formFactor,
        string? ddrVersion,
        int? powerConsumption)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        MemorySize = memorySize ?? throw new ArgumentNullException(nameof(memorySize));
        Jedecs = jedecs.ToList();
        XmpProfiles = xmpProfiles.ToList();
        FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        DdrVersion = ddrVersion ?? throw new ArgumentNullException(nameof(ddrVersion));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
    }

    public string Name { get; }
    public int MemorySize { get; }
    public IEnumerable<Jedec> Jedecs { get; }
    public IEnumerable<Xmp> XmpProfiles { get; }
    public string FormFactor { get; }
    public string DdrVersion { get; }
    public int PowerConsumption { get; }
    public IRamBuilder Direct(IRamBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithName(Name);
        builder.WithMemorySize(MemorySize);
        builder.WithFormFactor(FormFactor);
        builder.WithDdrVersion(DdrVersion);
        builder.WithPowerConsumption(PowerConsumption);

        foreach (Jedec jedec in Jedecs)
        {
            builder.AddJedec(jedec);
        }

        foreach (Xmp xmp in XmpProfiles)
        {
            builder.AddXmp(xmp);
        }

        return builder;
    }
}