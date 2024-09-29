using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapters;

public class WiFiAdapter : IBuildDirector<IWiFiAdapterBuilder>, IComponent
{
    public WiFiAdapter(
        string? name,
        string? wifiVersion,
        Bluetooth? bluetooth,
        string? pciVersion,
        int? powerConsumption)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        WiFiVersion = wifiVersion ?? throw new ArgumentNullException(nameof(wifiVersion));
        Bluetooth = bluetooth;
        PciVersion = pciVersion ?? throw new ArgumentNullException(nameof(pciVersion));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
    }

    public string Name { get; }
    public string WiFiVersion { get; }
    public Bluetooth? Bluetooth { get; }
    public string PciVersion { get; }
    public int PowerConsumption { get; }
    public IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithName(Name);
        builder.WithWiFiVersion(WiFiVersion);

        if (Bluetooth != null)
        {
            builder.WithBluetooth(Bluetooth);
        }

        builder.WithPciVersion(PciVersion);
        builder.WithPowerConsumption(PowerConsumption);

        return builder;
    }
}