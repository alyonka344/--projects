namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapters;

public interface IWiFiAdapterBuilder
{
    public IWiFiAdapterBuilder WithName(string name);
    public IWiFiAdapterBuilder WithWiFiVersion(string wifiVersion);
    public IWiFiAdapterBuilder WithBluetooth(Bluetooth bluetooth);
    public IWiFiAdapterBuilder WithPciVersion(string pciVersion);
    public IWiFiAdapterBuilder WithPowerConsumption(int powerConsumption);
    public WiFiAdapter Build();
}