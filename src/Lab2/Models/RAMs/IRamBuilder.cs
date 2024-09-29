using Itmo.ObjectOrientedProgramming.Lab2.Models.XMPs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.RAMs;

public interface IRamBuilder
{
    public IRamBuilder WithName(string name);
    public IRamBuilder WithMemorySize(int memorySize);
    public IRamBuilder AddJedec(Jedec jedec);
    public IRamBuilder AddXmp(Xmp xmpProfile);
    public IRamBuilder WithFormFactor(string formFactor);
    public IRamBuilder WithDdrVersion(string ddrVersion);
    public IRamBuilder WithPowerConsumption(int powerConsumption);
    public Ram Build();
}