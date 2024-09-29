namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapters;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private string? _name;
    private string? _wifiVersion;
    private Bluetooth? _bluetooth;
    private string? _pciVersion;
    private int? _powerConsumption;

    public IWiFiAdapterBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IWiFiAdapterBuilder WithWiFiVersion(string wifiVersion)
    {
        _wifiVersion = wifiVersion;
        return this;
    }

    public IWiFiAdapterBuilder WithBluetooth(Bluetooth bluetooth)
    {
        _bluetooth = bluetooth;
        return this;
    }

    public IWiFiAdapterBuilder WithPciVersion(string pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public IWiFiAdapterBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _name,
            _wifiVersion,
            _bluetooth,
            _pciVersion,
            _powerConsumption);
    }
}